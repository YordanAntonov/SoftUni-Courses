namespace CommandPattern.Core.Interfaces
{
    public interface ICommandInterpreter
    {
        string Read(string cmdName, string[] args);
    }
}
