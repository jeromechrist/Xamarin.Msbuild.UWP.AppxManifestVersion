[![Build status](https://ci.appveyor.com/api/projects/status/sdvls2q8v671e0b8?svg=true)](https://ci.appveyor.com/project/jeromechrist/xamarin-msbuild-uwp-appxmanifestversion)
[![NuGet](https://img.shields.io/nuget/v/Xamarin.Msbuild.UWP.AppxManifestVersion.svg)](https://www.nuget.org/packages/Xamarin.Msbuild.UWP.AppxManifestVersion/)

# Xamarin.Msbuild.UWP.AppxManifestVersion

forked from : [Readify/Xamarin.Msbuild](https://github.com/Readify/Xamarin.Msbuild)

![logo](https://github.com/jeromechrist/Xamarin.Msbuild.UWP.AppxManifestVersion/raw/master/nugeticon.png "logo")

Updated for uap10.0

#### usage : supply a AppVersion property

```C#
msbuild.exe /t:rebuild;publish /ToolsVersion:14.0 /property:AppVersion=1.0.0.0 /property:Configuration=Release /property:AppxBundle=Never /property:UapAppxPackageBuildMode=StoreOnly /property:BuildAppxUploadPackageForUap=false /property:Platform=x64
```

#### differences

* [.target file inline C# script](https://github.com/jeromechrist/Xamarin.Msbuild.UWP.AppxManifestVersion/blob/master/src/build/uap10.0/Xamarin.Msbuild.UWP.AppxManifestVersion.targets)
```C#
/*from*/ : XNamespace ns = "http://schemas.microsoft.com/appx/2010/manifest";
/*to*/   : XNamespace ns = "http://schemas.microsoft.com/appx/manifest/foundation/windows10";
```
To support project.json out of the box with the latest version of nuget [nuget docs](https://docs.nuget.org/ndocs/create-packages/creating-a-package#including-msbuild-props-and-targets-in-a-package)

*project.json : moved the .target inside a /build/uap10.0 folder
