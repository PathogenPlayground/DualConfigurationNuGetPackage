@echo off
color 0f
set MSBUILD="C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\MSBuild.exe"
%MSBUILD% DualConfigurationNuGetPackage.csproj /p:Configuration=Debug
%MSBUILD% DualConfigurationNuGetPackage.csproj /p:Configuration=Release
nuget pack DualConfigurationNuGetPackage.nuspec -OutputDirectory bin
pause
