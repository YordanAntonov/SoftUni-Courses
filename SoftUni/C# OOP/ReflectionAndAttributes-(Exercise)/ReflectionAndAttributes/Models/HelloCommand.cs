namespace CommandPattern.Models
{
    using CommandPattern.Core.Interfaces;
    using System;
    public class HelloCommand : ICommand
    {
        public string Execute(string[] args)
        {
            return $"Hello, {args[0]}";
        }
    }
}
