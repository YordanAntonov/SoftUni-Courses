namespace CommandPattern.Models
{
    using CommandPattern.Core.Contracts;
    using System;
    public class HelloCommand : ICommand
    {
        public string Execute(string[] args)
        {
            return $"Hello, {args[0]}";
        }
    }
}
