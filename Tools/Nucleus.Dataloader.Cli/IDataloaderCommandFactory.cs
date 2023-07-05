namespace Nucleus.Dataloader.Cli
{
    public interface IDataloaderCommandFactory
    {
        Task ExecuteAsync(DataLoaderActions action, Type type, object database, CancellationToken cancellationToken);
    }
}