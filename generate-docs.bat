
ECHO "restore current .net tools"
dotnet tool restore

ECHO "Build Web Project"
dotnet build ^
Nucleus.Net.Libs.sln ^
--configuration Release

CALL test.bat --no-start

dotnet msbuild /T:BuildSwagger Eliassen.WebApi

ECHO "Copy Code Coverage Results"
COPY .\TestResults\Cobertura.coverage .\docs\Tests\Cobertura.coverage
ECHO "Copy Code Test Results"
COPY .\TestResults\LatestTestResults.trx .\docs\Tests\LatestTestResults.trx
ECHO "Copy Code Coverage Report"
COPY .\TestResults\Coverage\Reports\Summary.md .\docs\Tests\Summary.md

ECHO "Generate Service-Endpoints"
dotnet run ^
--project Tools\Eliassen.TemplateEngine.Cli ^
--configuration Release ^
-- ^
--input .\docs\swagger.json ^
--output .\docs\Service-Endpoints.md ^
--Template Service-Endpoints ^
--file-template-path .\Tools\Eliassen.TemplateEngine.Cli\bin\Release\net8.0

ECHO "Generate - Library Docs"

dotnet run ^
--project Tools\Eliassen.TemplateEngine.Cli ^
--configuration Release ^
-- ^
--input .\Examples\Eliassen.WebApi\bin\Release\net8.0\*.xml ^
--output .\docs\Libraries\[file].md ^
--Template Documentation.md ^
--file-template-path .\Tools\Eliassen.TemplateEngine.Cli\bin\Release\net8.0

ECHO "Generate - Test Result"
dotnet run ^
--project Tools\Eliassen.TemplateEngine.Cli ^
--configuration Release ^
-- ^
--input .\TestResults\*.trx ^
--output .\docs\Tests\[file].md ^
--Template TestResultsToMarkdown.md ^
--file-template-path .\Tools\Eliassen.TemplateEngine.Cli\bin\Release\net8.0 ^
--input-type XML

