# Project Setup

## Dependancies
Below is a list of resources that you need to install to run this app (Excluding base dev tools)
- MongoDb Server (Docker instance is ideal)
- Optional: MongoDbCompass
- Azure Storage Emulator
- Optional: Azure Storage Explorer

[Instructions for Setting up your mongoDb](MongoDbSetup.md) 

## Re-purposing this project
The concept behind the naming convention of Nucleus. in this project is to easily be able to re-name 
all namespaces and projects to your desired namespace. This process should take you 10-15 minutes to complete

1. Rename all folders from Nucleus. -> {ProjectSpace}.
2. Rename Solution File from Nucleus.Acc.Net.Api.sln -> {ProjectSpace}.Api.sln
3. Open the solution file in NotePad that you renamed in step 2
   - Find and replace all  (must include the comma, space and double quote)
	-Find:, "Nucleus.
 	-Replace:, "ProjectSpace.
   - Save the solution file from notepad
4. Open the solution and re-name all of your project files from Nuclues. -> {ProjectSpace}.
5. Find and replace in all files "Nucleus." -> "ProjectSpace."
6. Find and replace in all files "new Nucleus" -> "new ProjectSpace"
7. Clean/Build the solution to ensure all projects and namespaces are now aligned
8. Install Azure Storage Emulator (and optionally azure storage explorer)
   - add the following Storage Container "{ProjectSpace}-filestore"