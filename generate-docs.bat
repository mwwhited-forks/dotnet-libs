
@ECHO OFF
SETLOCAL EnableDelayedExpansion

SET SolutionDir=%~dp0
ECHO SolutionDir %SolutionDir%
SET PublishPath=%SolutionDir%publish\libs\
ECHO PublishPath %PublishPath%

ECHO "restore current .net tools"
dotnet tool restore

ECHO "Build Web Project"
dotnet build ^
Nucleus.Net.Libs.sln ^
--configuration Release ^
--output %PublishPath%

CALL test.bat --no-start

dotnet msbuild /T:BuildSwagger .\Examples\Eliassen.WebApi
dotnet build Nucleus.Net.Libs.sln /T:GetDocumentation

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
RMDIR .\docs\Libraries /S/Q
dotnet run ^
--project Tools\Eliassen.TemplateEngine.Cli ^
--configuration Release ^
-- ^
--input %PublishPath%*.xml ^
--output .\docs\Libraries\[file].md ^
--Template Documentation.md ^
--file-template-path .\docs\templates
DEL .\docs\Libraries\Microsoft*.* /Q

RMDIR .\docs\Tests /S/Q
ECHO "Copy Code Coverage Results"
COPY .\TestResults\Cobertura.coverage .\docs\Tests\Cobertura.coverage /Y
ECHO "Copy Code Test Results"
COPY .\TestResults\Coverage\Reports\LatestTestResults.trx .\docs\Tests\LatestTestResults.trx /Y
ECHO "Copy Code Coverage Report"
COPY .\TestResults\Coverage\Reports\Summary.md .\docs\Tests\Summary.md /Y

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
