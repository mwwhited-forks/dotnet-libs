namespace Nucleus.Dataloader.Cli
{
    public interface IDataloaderCommand
    {
        DataLoaderActions Action { get; }
        int Priority { get; }
        Task ExecuteAsync(string collectionName, Type elementType, object data, CancellationToken cancellationToken);
    }
}