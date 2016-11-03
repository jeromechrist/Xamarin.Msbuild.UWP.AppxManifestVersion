# Xamarin.Msbuild.UWP.AppxManifestVersion

forked from : [Readify/Xamarin.Msbuild](https://github.com/Readify/Xamarin.Msbuild)

![logo](https://github.com/jeromechrist/Xamarin.Msbuild.UWP.AppxManifestVersion/raw/master/nugeticon.png "logo")

Updated for uap10.0

#### differences :

```C#
/*from*/ : XNamespace ns = "http://schemas.microsoft.com/appx/2010/manifest";
/*to*/   : XNamespace ns = "http://schemas.microsoft.com/appx/manifest/foundation/windows10";
```
To support project.json out of the box with the latest version of nuget [nuget docs](https://docs.nuget.org/ndocs/create-packages/creating-a-package#including-msbuild-props-and-targets-in-a-package)

moved the .target inside a /build/uap10.0 folder
