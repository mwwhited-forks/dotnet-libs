
dotnet tool restore

dotnet sonarscanner begin ^
/k:"Lightwell-Nucleus_Nucleus.Net.Libs_AY1rEe7JXbPtYw2Rxn60" ^
/d:sonar.host.url="http://localhost:9000" ^
/d:sonar.token="sqp_19ee9e7d6345e65dd413660300bbbc596c8ec7ba"

REM /d:sonar.projectVersion

dotnet build

dotnet sonarscanner end ^
/d:sonar.token="sqp_19ee9e7d6345e65dd413660300bbbc596c8ec7ba"
