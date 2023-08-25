
dotnet run ^
--project Tools\Nucleus.Dataloader.Cli ^
--configuration Release ^
-- ^
--SourcePath=.\Conf\MongoDb\SampleData ^
--Action=DropCollectionAndImport ^
--ConnectionString=mongodb://localhost:27017 ^
--DatabaseName=nucleus