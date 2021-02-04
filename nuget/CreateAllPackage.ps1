$targets = @(
   "CPU"
)

$ScriptPath = $PSScriptRoot
$OpenJijDotNetRoot = Split-Path $ScriptPath -Parent

$source = Join-Path $OpenJijDotNetRoot src | `
          Join-Path -ChildPath OpenJijDotNet
dotnet restore ${source}
dotnet build -c Release ${source}

foreach ($target in $targets)
{
   pwsh CreatePackage.ps1 $target
}