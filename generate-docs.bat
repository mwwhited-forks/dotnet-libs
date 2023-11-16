
ECHO "restore current .net tools"
dotnet tool restore

ECHO "Build Projects"
dotnet build ^
Nucleus.Net.Libs.sln ^
--configuration Release

CALL test.bat --no-start

ECHO "Copy Code Coverage Results"
COPY .\TestResults\Cobertura.coverage .\docs\Tests\Cobertura.coverage
ECHO "Copy Code Test Results"
COPY .\TestResults\LatestTestResults.trx .\docs\Tests\LatestTestResults.trx
ECHO "Copy Code Coverage Report"
COPY .\TestResults\Coverage\Reports\Summary.md .\docs\Tests\Summary.md

