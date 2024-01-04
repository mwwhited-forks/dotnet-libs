
REM @REM SET
@ECHO OFF
SETLOCAL

SET TestProject=Nucleus.Net.Libs.sln
REM SET Configuration=Debug
SET Configuration=Release

SET LATEST_TEST_RESULTS_TRX=.\TestResults\Coverage\Reports\LatestTestResults.trx

IF "%1"=="--no-start" (
	SET DO_NOT_START=1
	SHIFT
)
IF "%1"=="--no-run" (
	SET DO_NOT_RUN=1
	SHIFT
)

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

RMDIR .\TestResults /S/Q
ECHO "%TestFilter%"

dotnet tool install --global dotnet-reportgenerator-globaltool 2>NUL

IF '%DO_NOT_RUN%'=='' (
RMDIR /S/Q ".\TestResults" 2>NUL
MKDIR ".\TestResults\Coverage\Reports" 2>NUL

dotnet test "%TestProject%" ^
--configuration %Configuration% ^
--results-directory .\TestResults ^
--nologo ^
--settings .runsettings ^
--filter "%TestFilter%"
)

SET TEST_ERR=%ERRORLEVEL%

REM the code coverage report tool below does not support source linked files
ECHO "Run Fix-SourceLink"
dotnet run ^
--project Tools\Eliassen.FixSourceLinks.Cli ^
--configuration Release ^
-- ^
--include=.\TestResults\**\coverage.*;.\TestResults\**\Cobertura.* ^
--target=.\

REM .\\TestResults\\**\\coverage.*;.\\TestResults\\**\\Cobertura.*

ECHO "Run dotnet-coverage merge"
dotnet dotnet-coverage merge ^
coverage.*.xml ^
--recursive ^
--output .\TestResults\Cobertura.coverage ^
--output-format cobertura

ECHO "Run trx-merge"
dotnet trx-merge --dir=.\TestResults --output=%LATEST_TEST_RESULTS_TRX% --loglevel=Verbose --recursive
REM TODO: there is bug in the tool above so this fixes it
pwsh -Command "& {param($FileName) (Get-Content $FileName).Replace('xmlns=""""','') | Set-Content $FileName }" -ArgumentList ignored %LATEST_TEST_RESULTS_TRX%

ECHO "Run reportgenerator"
REM TODO: fix this https://github.com/danielpalme/ReportGenerator/wiki/Integration
reportgenerator "-reports:.\TestResults\**\coverage.*.xml" "-targetDir:.\TestResults\Coverage\Reports" -reportTypes:HtmlSummary;Cobertura;MarkdownSummary "-title:%TestProject% - (%Configuration%)"

IF '%DO_NOT_START%'=='' (
START .\TestResults\Coverage\Reports\summary.html
START .\TestResults\Cobertura.coverage
START %LATEST_TEST_RESULTS_TRX%
)

ECHO TEST_ERR=%TEST_ERR%
IF "%TEST_ERR%"=="0" (
	ECHO "No Errors :)"
)
ENDLOCAL

