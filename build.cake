//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

// Define directories.
var buildDir = Directory("TestProject/TestProject/bin") + Directory(configuration);

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() =>
{
    CleanDirectory(buildDir);
    CleanDirectory(Directory("TestProject/TestProject/AppPackages"));
});

Task("Restore-NuGet-Packages")
    .IsDependentOn("Clean")
    .Does(() =>
{
    NuGetRestore("TestProject/TestProject.sln");
});

Task("Build")
    .IsDependentOn("Restore-NuGet-Packages")
    .Does(() =>
{
    if(IsRunningOnWindows())
    {
      // Use MSBuild
      MSBuild("TestProject/TestProject.sln", settings =>
        settings.SetConfiguration(configuration)
        .WithProperty("AppVersion", "9.9.9.9")
        .WithProperty("AppxBundle", "Never")
        .WithProperty("UapAppxPackageBuildMode", "StoreOnly")
        .WithProperty("BuildAppxUploadPackageForUap", "false")
        );
    }
    else
    {
      // Use XBuild
      XBuild("TestProject/TestProject.sln", settings =>
        settings.SetConfiguration(configuration));
    }
});

Task("AssertIsWorking")
    .IsDependentOn("Build")
    .Does(() =>
{
    if (!FileExists("TestProject/TestProject/AppPackages/TestProject_9.9.9.9_ARM_Test/TestProject_9.9.9.9_ARM.appx"))
    {
        throw new Exception("Sometehing went wrong: Appx with the AppVersion supplied not found");
    }
});


//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("AssertIsWorking");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
