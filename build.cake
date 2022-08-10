#addin nuget:?package=SimpleExec&version=10.0.0
#addin "nuget:?package=Cake.MinVer&version=2.0.0"

using System.Text.Json;
using SimpleExec;

var target = Argument("Target", "Default");

var configuration =
    HasArgument("Configuration") ? Argument<string>("Configuration") :
    EnvironmentVariable("Configuration", "Release");

var shouldPack = HasArgument("pack") ? Argument<bool>("pack") : false;

var settings = new MinVerSettings()
{
    AutoIncrement = MinVerAutoIncrement.Minor,
    DefaultPreReleasePhase = "preview",
    MinimumMajorMinor = "1.0",
    TagPrefix = "v",
    Verbosity = MinVerVerbosity.Trace,
};

var version = MinVer(settings);

Task("Clean")
    .Description("Cleans the artifacts, bin and obj directories.")
    .Does(() =>
    {
        DeleteDirectories(GetDirectories("**/bin"), new DeleteDirectorySettings() { Force = true, Recursive = true });
        DeleteDirectories(GetDirectories("**/obj"), new DeleteDirectorySettings() { Force = true, Recursive = true });
        CleanDirectory("./artifacts");
    });

Task("Restore")
    .Description("Restores NuGet packages.")
    .IsDependentOn("Clean")
    .Does(() =>
    {
        DotNetRestore();
    });

Task("Build")
    .Description("Builds the solution.")
    .IsDependentOn("Restore")
    .Does(() =>
    {
        DotNetBuild(
            ".",
            new DotNetBuildSettings()
            {
                Configuration = configuration,
                NoRestore = true,
                ArgumentCustomization = args => 
                  args
                  .Append($"-p:Version={version}")
                  .Append($"-p:InformationalVersion={version}"),
            });
    });

Task("Test")
    .Description("Runs unit tests and outputs test results to the artifacts directory.")
    .DoesForEach(GetFiles("./tests/**/*.csproj"), project =>
    {
        DotNetTest(
            project.ToString(),
            new DotNetTestSettings()
            {
                Blame = true,
                Collectors = new string[] { "Code Coverage", "XPlat Code Coverage" },
                Configuration = configuration,
                Loggers = new string[]
                {
                    $"trx;LogFileName={project.GetFilenameWithoutExtension()}.trx",
                    $"html;LogFileName={project.GetFilenameWithoutExtension()}.html",
                },
                NoBuild = true,
                NoRestore = true,
            });
    });

Task("Pack")
    .Description("Packs the Required Project")
    .IsDependentOn("Test")
    .WithCriteria(shouldPack)
    .Does(() =>
        {
            DotNetPack("src/SimCube.Spartan/SimCube.Spartan.csproj",
             new DotNetCorePackSettings()
                        {
                            NoBuild = true,
                            NoRestore = true,
                            NoLogo = true,
                            OutputDirectory = "./artifacts",
                            Verbosity = DotNetVerbosity.Minimal,
                            Configuration = configuration,
                            ArgumentCustomization = builder => builder.Append($"-p:PackageVersion={version}")
                        });
        });

Task("Default")
    .Description("Cleans, restores NuGet packages, builds the solution and then runs unit tests.")
    .IsDependentOn("Build")
    .IsDependentOn("Test")
    .IsDependentOn("Pack");

RunTarget(target);
