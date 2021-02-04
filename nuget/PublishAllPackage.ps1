#***************************************
#Arguments
#%1: Test Package (OpenJijDotNet.CUDA92)
#%2: Version of Release (19.17.0.yyyyMMdd)
#***************************************
Param([Parameter(
      Mandatory=$True,
      Position = 1
      )][string]
      $Version,

      [Parameter(
      Mandatory=$True,
      Position = 2
      )][string]
      $Token
)

dotnet nuget push OpenJijDotNet.${Version}.nupkg -k ${Token} -s https://api.nuget.org/v3/index.json