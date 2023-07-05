namespace Nucleus.Dataloader.Cli
{
    [Flags]
    public enum DataLoaderActions
    {
        Unknown = 0,
        Export = 1,
        Import = 2,
        DropCollection = 4,
        DropCollectionAndImport = DropCollection | Import,
    }
}