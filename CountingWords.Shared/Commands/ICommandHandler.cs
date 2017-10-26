namespace CountingWords.Shared.Commands
{
    /// <summary>
    /// Interface to Handler
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICommandHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
