$artifacts = "$PSScriptRoot\..\artifacts"

if(Test-Path $artifacts) { Remove-Item $artifacts -Force -Recurse }

dotnet pack $PSScriptRoot\..\src\Aspectify\Aspectify.csproj -c Release -o $artifacts