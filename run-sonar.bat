
dotnet tool restore

echo "Git fetch"
git fetch --prune
FOR /F "tokens=* USEBACKQ" %%g IN (`dotnet gitversion /output json /showvariable FullSemVer`) DO (SET BUILD_VERSION=%%g)
if "%BUILD_VERSION%"=="" GOTO error
ECHO Building Version=  "%BUILD_VERSION%"

dotnet sonarscanner begin ^
/k:"Lightwell-Nucleus_Nucleus.Net.Libs_AY1rEe7JXbPtYw2Rxn60" ^
/d:sonar.host.url="http://localhost:9000" ^
/d:sonar.token="sqp_19ee9e7d6345e65dd413660300bbbc596c8ec7ba" ^
/v:"%BUILD_VERSION%"

dotnet build

dotnet sonarscanner end ^
/d:sonar.token="sqp_19ee9e7d6345e65dd413660300bbbc596c8ec7ba"
