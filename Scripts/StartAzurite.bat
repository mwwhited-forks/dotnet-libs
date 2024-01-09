
@ECHO OFF

SET PATH=%PATH%;%ProgramFiles%\Microsoft Visual Studio\2022\Enterprise\Common7\IDE\Extensions\Microsoft\Azure Storage Emulator\
SET PATH=%PATH%;%ProgramFiles%\Microsoft Visual Studio\2022\Professional\Common7\IDE\Extensions\Microsoft\Azure Storage Emulator\

SET AzuriteLocation=%TEMP%\azurite
IF NOT EXIST "%AzuriteLocation%" MKDIR "%AzuriteLocation%"

START "Azurite Storage Emulator" azurite --location %AzuriteLocation%