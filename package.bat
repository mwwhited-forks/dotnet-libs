
IF "%1"=="--clean" (
	RMDIR .\publish\packages /Q/S
	SHIFT
)

dotnet pack ^
--configuration Release ^
--output .\publish\packages ^
Nucleus.Net.Libs.sln 
