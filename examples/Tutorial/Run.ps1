#***************************************
#Arguments
#%1: Test Package (OpenJijDotNet.CUDA92)
#%2: Version of Release (19.17.0.yyyyMMdd)
#***************************************
Param([Parameter(
      Mandatory=$True,
      Position = 1
      )][string]
      $Package,

      [Parameter(
      Mandatory=$True,
      Position = 2
      )][string]
      $Version,

      [Parameter(
      Mandatory=$True,
      Position = 3
      )][string]
      $PlatformTarget
)

Set-StrictMode -Version Latest

function Clear-PackageCache([string]$Package, [string]$Version)
{
   $path = (dotnet nuget locals global-packages --list).Replace('info : global-packages: ', '').Trim()
   if ($path)
   {
      $path = (dotnet nuget locals global-packages --list).Replace('global-packages: ', '').Trim()
   }
   $path =  Join-Path $path $Package.ToLower() | `
            Join-Path -ChildPath $Version.ToLower()
   if (Test-Path $path)
   {
      Write-Host "[Info] Remove '$path'" -Foreground Green
      Remove-Item -Path "$path" -Recurse -Force
   }
   else
   {
      Write-Host "[Info] Missing '$path'" -Foreground Yellow
   }
}

function Run()
{
   $ErrorActionPreference = "silentlycontinue"
   $env:PlatformTarget = $PlatformTarget
   $dotnetPath = ""
   $runsetting = ""
   if ($global:IsWindows)
   {
      switch($PlatformTarget)
      {
         "x64"
         {
            $dotnetPath = Join-Path $env:ProgramFiles "dotnet\dotnet.exe"
         }
         "x86"
         {
            $dotnetPath = Join-Path ${env:ProgramFiles(x86)} "dotnet\dotnet.exe"
         }
      }
   }
   else
   {
      $dotnetPath = "dotnet"
   }

   switch($PlatformTarget)
   {
      "x64"
      {
         $runsetting = "x64.runsettings"
      }
      "x86"
      {
         $runsetting = "x86.runsettings"
      }
   }

   Write-Host "[Info] Clear-PackageCache" -Foreground Yellow
   Clear-PackageCache -Package $Package -Version $Version

   # Test
   $WorkDir = Join-Path $OpenJijDotNetRoot "examples" | `
              Join-Path -ChildPath "Tutorial"
   $NugetDir = Join-Path $OpenJijDotNetRoot nuget

   # restore package from local nuget pacakge
   # And drop stdout message
   Write-Host "[Info] Remove Reference from ${TestDir}" -Foreground Yellow
   Set-Location ${WorkDir}
   dotnet remove reference "..\..\src\OpenJijDotNet\OpenJijDotNet.csproj" > $null

   Write-Host "[Info] Add Package to ${TestDir}" -Foreground Yellow
   Set-Location ${WorkDir}
   dotnet add package $package -v $VERSION --source "$NugetDir" > $null

   Write-Host "${dotnetPath} run -c Release" -Foreground Yellow
   & ${dotnetPath} run -c Release

   Write-Host "[Info] Revert modification for Tutorial.csproj" -Foreground Yellow
   git checkout Tutorial.csproj
}

# Store current directory
$Current = Get-Location
$ExampleRoot = (Split-Path (Get-Location) -Parent)
$OpenJijDotNetRoot = (Split-Path $ExampleRoot -Parent)

Run

# Move to Root directory
Set-Location -Path $Current