
dotnet build Nucleus.Acc.Net.Api.sln ^
--configuration Release ^
--nologo ^
/p:DeployOnBuild=true ^
/p:WebPublishMethod=Package ^
/p:PackageAsSingleFile=true ^
/p:SkipInvalidConfigurations=true ^
/p:DesktopBuildPackageLocation="..\Publish\WebApp.zip" ^
/p:DeployIisAppPath="Default Web Site"
