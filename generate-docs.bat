
@ECHO OFF
SETLOCAL EnableDelayedExpansion

SET SolutionDir=%~dp0
ECHO SolutionDir %SolutionDir%
SET PublishPath=%SolutionDir%publish\libs\
ECHO PublishPath %PublishPath%

SET TARGET_SOLUTION=Eliassen.Libs.sln
SET TARGET_SOLUTION_NAME=Nucleus.Libs
SET TARGET_WEB_PROJECT=.\Examples\Eliassen.WebApi\Eliassen.WebApi.csproj

ECHO "restore current .net tools"
dotnet tool restore

echo "Git fetch"
git fetch --prune
FOR /F "tokens=* USEBACKQ" %%g IN (`dotnet gitversion /output json /showvariable FullSemVer`) DO (SET BUILD_VERSION=%%g)
if "%BUILD_VERSION%"=="" GOTO error
ECHO Building Version=  "%BUILD_VERSION%"

REM GOTO :sbom

dotnet format ^
--verbosity detailed ^
--report %PublishPath%..\reports\format.json

CALL build.bat
SET TEST_ERR=%ERRORLEVEL%
IF NOT "%TEST_ERR%"=="0" (
	ECHO "Build Failed! %TEST_ERR%"
	GOTO :skiptoend
)

ECHO "Generate - swagger docs"
dotnet build /T:BuildSwagger %TARGET_WEB_PROJECT%

ECHO "Generate Service-Endpoints"
REM dotnet templateengine ^
dotnet run ^
--project Tools\Eliassen.TemplateEngine.Cli ^
--configuration Release ^
--input .\docs\swagger.json ^
--output .\docs\Service-Endpoints.md ^
--Template Service-Endpoints ^
--file-template-path .\docs\templates

ECHO "Generate - Library code docs"
RMDIR .\docs\code /S/Q
dotnet build /T:GetDocumentation

ECHO "Generate - Library Docs"
RMDIR .\docs\Libraries /S/Q
dotnet run ^
--project Tools\Eliassen.TemplateEngine.Cli ^
--configuration Release ^
--input %PublishPath%*.xml ^
--output .\docs\Libraries\[file].md ^
--Template Documentation.md ^
--file-template-path .\docs\templates
DEL .\docs\Libraries\Microsoft*.* /Q

ECHO "Generate - Test Docs"
CALL test.bat --no-start
SET TEST_ERR=%ERRORLEVEL%
IF NOT "%TEST_ERR%"=="0" (
	ECHO "Tests Failed! %TEST_ERR%"
	GOTO :skiptoend
)

RMDIR .\docs\Tests /S/Q
MKDIR .\docs\Tests
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
--input .\TestResults\Coverage\Reports\*.trx ^
--output .\docs\Tests\[file].md ^
--Template TestResultsToMarkdown.md ^
--file-template-path .\docs\templates ^
--input-type XML

:sbom
ECHO "Generate - Software Bill of Materials (bom.xml)"
RMDIR .\docs\sbom /S/Q
REM https://github.com/CycloneDX/cyclonedx-dotnet
dotnet CycloneDX ^
--output .\docs\sbom ^
--set-version %BUILD_VERSION% ^
--set-name %TARGET_SOLUTION_NAME% ^
--exclude-test-projects ^
--disable-package-restore ^
--exclude-dev ^
%TARGET_SOLUTION%
REM .\sbom.csproj
SET TEST_ERR=%ERRORLEVEL%
IF NOT "%TEST_ERR%"=="0" (
	ECHO "SBOM Failed! %TEST_ERR%"
	GOTO :skiptoend
)

REM --include-project-references ^
REM --enable-github-licenses ^

ECHO "Generate - Software Bill of Materials (report)"
dotnet run ^
--project Tools\Eliassen.TemplateEngine.Cli ^
--configuration Release ^
--input .\docs\sbom\bom.xml ^
--output .\docs\sbom\BillOfMaterials.md ^
--Template SoftwareBillOfMaterials.md ^
--file-template-path .\docs\templates ^
--input-type XML

ECHO TEST_ERR=%TEST_ERR%
:skiptoend
IF "%TEST_ERR%"=="0" (
	ECHO "No Errors :)"
)
EXIT /B %TEST_ERR%
:EOF
ENDLOCAL