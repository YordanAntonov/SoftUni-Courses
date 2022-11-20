namespace CommandPattern.Models
{
    using System;
    using CommandPattern.Core.Contracts;

    public class ExitCommand : ICommand
    {
        private const int DefailtErrorCode = 0;
        public string Execute(string[] args)
        {
            Environment.Exit(DefailtErrorCode);
            return null;
        }
    }
}
