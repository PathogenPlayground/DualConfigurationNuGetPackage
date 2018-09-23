# Dual Configuration NuGet Package

This repository is a quick proof of concept that I made for a NuGet package that contains both debug and release assemblies. It was inspired by [this tweet](https://twitter.com/xoofx/status/1043778282792075264) by Alexandre Mutel.

It basically works by subverting the normal NuGet assembly reference process and manually adding the assembly reference in `DualConfigurationNuGetPackage.targets`.

By default it will automatically use the same configuration as the referencing project, but you can override it by adding a `DualConfigurationNuGetPackage_Configuration` property to your configuration. (The `WeirdConfiguration` configuration in `TestConsumer` demonstrates this.) If the configuration is invalid, an error message is displayed in the MSBuild log.

## Disclaimers

I have not tested this extensively. There could be some subtle issues with the way it works that will prevent it from working in a real scenario.

I did not test it with the new `csproj` format (for either the package or the consumer.) It probably works for the consumer, but I didn't test it. Extra work is definitely necessary to get it to play nice with new `csproj` packages with the package info in the project.

## Known Issues / Limitations

* Visual Studio will show the NuGet reference twice in the references listing. (Once for the actual package, once for our manual assembly refernece.) It will also usually be wrong (it will point to the reference used when the project was loaded.) I imagine there's a way to suppress this, but I'm not sure how.
* It seems to confuse Intellisense when the package is added until you build.
* Right now the `make-nuget-package.bat` uses a hard-coded location for `msbuild.exe`.
* Since you're subverting the way NuGet normally adds assembly references, there's nothing smart going on to select the right assembly for the current SDK. (You could probably add this though.)
* You will get NU5100 warnings when packing the NuGet package.

## Using the Demonstration

### From MyGet

The package is published at [pathogen-playground/DualConfigurationNuGetPackage](https://www.myget.org/feed/pathogen-playground/package/nuget/DualConfigurationNuGetPackage) on MyGet.

* Add this feed as a NuGet package source. (Or install the package manually using the explicit source.)
* Open `TestConsumer.sln` and build/run the various configurations. It will print what configuration the library was built with.

### Self-Built

* The project assumes `msbuild.exe` is located at `C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\MSBuild.exe`. If you have a different edition of Visual Studio or changed the install location, modify `DualConfigurationNuGetPackage\make-nuget-package.bat` accordingly.
* Run `DualConfigurationNuGetPackage\make-nuget-package.bat`, this will build the project for `Debug` and `Release` configurations and pack the NuGet package.
* Install the `DualConfigurationNuGetPackage\bin\DualConfigurationNuGetPackage.1.0.0.nupkg` in your local NuGet package repository.
* Open `TestConsumer.sln` and build/run the various configurations. It will print what configuration the library was built with.
