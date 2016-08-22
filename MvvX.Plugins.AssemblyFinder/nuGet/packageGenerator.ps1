$location  = Get-Location

$location.Path

$strPath = $location.Path + '\..\MvvX.Plugins.AssemblyFinder\bin\Release\MvvX.Plugins.AssemblyFinder.dll'

$strPath

$Assembly = [Reflection.Assembly]::Loadfile($strPath)
$AssemblyName = $Assembly.GetName()
$Assemblyversion =  $AssemblyName.version
$Assemblyversion

$nuSpecFile =  $location.Path + '\MvvX.Plugins.AssemblyFinder.nuspec'

(Get-Content $nuSpecFile) | 
Foreach-Object {$_ -replace "(<version>([0-9.]+)-pre<\/version>)", "<version>$Assemblyversion-pre</version>" } | 
Set-Content $nuSpecFile

.\NuGet pack MvvX.Plugins.AssemblyFinder.nuspec

$apiKey = Read-Host 'Please set apiKey to publish to nuGet :'
	
.\NuGet push MvvX.Plugins.AssemblyFinder.$Assemblyversion-pre.nupkg -Source https://www.nuget.org/api/v2/package -ApiKey $apiKey
