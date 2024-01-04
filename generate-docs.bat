
SETLOCAL EnableDelayedExpansion

SET SolutionDir=%~dp0

ECHO "restore current .net tools"
dotnet tool restore

ECHO "Build Web Project"
dotnet build ^
Nucleus.Net.Libs.sln ^
--configuration Release ^
--output .\publish\libs\

CALL test.bat --no-start

dotnet msbuild /T:BuildSwagger .\Examples\Eliassen.WebApi
dotnet build Nucleus.Net.Libs.sln /T:GetDocumentation

ECHO "Copy Code Coverage Results"
COPY .\TestResults\Cobertura.coverage .\docs\Tests\Cobertura.coverage /Y
ECHO "Copy Code Test Results"
COPY .\TestResults\Coverage\Reports\LatestTestResults.trx .\docs\Tests\LatestTestResults.trx /Y
ECHO "Copy Code Coverage Report"
COPY .\TestResults\Coverage\Reports\Summary.md .\docs\Tests\Summary.md /Y

ECHO "Generate Service-Endpoints"
dotnet run ^
--project Tools\Eliassen.TemplateEngine.Cli ^
--configuration Release ^
-- ^
--input .\docs\swagger.json ^
--output .\docs\Service-Endpoints.md ^
--Template Service-Endpoints ^
--file-template-path .\docs\templates

ECHO "Generate - Library Docs"

dotnet run ^
--project Tools\Eliassen.TemplateEngine.Cli ^
--configuration Release ^
-- ^
--input .\Examples\Eliassen.WebApi\bin\Release\net8.0\*.xml ^
--output .\docs\Libraries\[file].md ^
--Template Documentation.md ^
--file-template-path .\docs\templates

ECHO "Generate - Test Result"
dotnet run ^
--project Tools\Eliassen.TemplateEngine.Cli ^
--configuration Release ^
-- ^
--input .\TestResults\Coverage\Reports\*.trx ^
--output .\docs\Tests\[file].md ^
--Template TestResultsToMarkdown.md ^
--file-template-path .\docs\templates ^
--input-type XML

ENDLOCAL
