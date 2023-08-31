
REM @REM SET
@echo off
SETLOCAL

SET TestProject=Nucleus.Acc.Net.Api.sln
REM SET Configuration=Debug
SET Configuration=Release

IF NOT "%1"=="" IF NOT "%TestFilter%"=="" SET TestFilter=

:check_again
IF "%1"=="" GOTO ready_to_run

SET temp_filter=%1
IF "%TestFilter%"=="" (
	SET TestFilter=TestCategory=%temp_filter%
) ELSE (
	SET TestFilter=%TestFilter%^|TestCategory=%temp_filter%
)

SHIFT
GOTO check_again

:ready_to_run
IF "%TestFilter%"=="" SET TestFilter=TestCategory=Unit^|TestCategory=Simulate

ECHO "%TestFilter%"

dotnet tool install --global dotnet-reportgenerator-globaltool 2>NUL
rmdir /s/q ".\TestResults"

dotnet test "%TestProject%" ^
--configuration %Configuration% ^
--results-directory .\TestResults ^
--nologo ^
--settings .runsettings ^
--filter "%TestFilter%"
--logger trx 

SET TEST_ERR=%ERRORLEVEL%

REM dotnet pack "Lightwell.FixSourceLinks.Cli" --configuration Release -o "Publish\Nuget"
REM dotnet tool install Lightwell.FixSourceLinks.Cli --add-source=Publish\Binary --version 1.0.0
REM dotnet fix-sourcelink --include=.\TestResults\**\coverage.cobertura.xml --target=..\..
REM dotnet tool uninstall Lightwell.FixSourceLinks.Cli

dotnet dotnet-coverage merge ^
coverage.*.xml ^
--recursive ^
--output .\TestResults\Cobertura.coverage ^
--output-format cobertura

reportgenerator ^
"-reports:.\TestResults\**\coverage.cobertura.xml" ^
"-targetDir:.\TestResults\Coverage\Reports" ^
-reportTypes:HtmlSummary;Cobertura ^
"-title:%TestProject% - (%USERNAME%)"

start .\TestResults\Coverage\Reports\summary.html
start .\TestResults\Cobertura.coverage
start .\TestResults\LatestTestResults.trx

ECHO TEST_ERR=%TEST_ERR%
IF "%TEST_ERR%"=="0" (
	ECHO "No Errors :)"
)
ENDLOCAL

