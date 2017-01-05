write-host "**************************" -foreground "Cyan"
write-host "*   Packaging to nuget   *" -foreground "Cyan"
write-host "**************************" -foreground "Cyan"

#$location  = "C:\Sources\NoSqlRepositories";
$location  = $env:APPVEYOR_BUILD_FOLDER

$locationNuspec = $location + "\nuspec"
$locationNuspec
	
Set-Location -Path $locationNuspec

$strPath = $location + '\MvvX.Plugins.AssemblyFinder\bin\Release\MvvX.Plugins.AssemblyFinder.dll'

$VersionInfos = [System.Diagnostics.FileVersionInfo]::GetVersionInfo($strPath)
$ProductVersion = $VersionInfos.ProductVersion
write-host "Product version : " $ProductVersion -foreground "Green"

write-host "Packaging to nuget..." -foreground "Magenta"

write-host "Update nuspec versions" -foreground "Green"

write-host "Update nuspec versions MvvX.Plugins.AssemblyFinder.nuspec" -foreground "DarkGray"
$nuSpecFile =  $locationNuspec + '\MvvX.Plugins.AssemblyFinder.nuspec'
(Get-Content $nuSpecFile) | 
Foreach-Object {$_ -replace "{BuildNumberVersion}", "$ProductVersion" } | 
Set-Content $nuSpecFile

write-host "Generate nuget packages" -foreground "Green"

write-host "Generate nuget package for MvvX.Plugins.AssemblyFinder.nuspec" -foreground "DarkGray"
.\NuGet.exe pack MvvX.Plugins.AssemblyFinder.nuspec

$apiKey = $env:NuGetApiKey
	
write-host "Publish nuget packages" -foreground "Green"

write-host MvvX.Plugins.AssemblyFinder.$ProductVersion.nupkg -foreground "DarkGray"
.\NuGet push MvvX.Plugins.AssemblyFinder.$ProductVersion.nupkg -Source https://www.nuget.org/api/v2/package -ApiKey $apiKey