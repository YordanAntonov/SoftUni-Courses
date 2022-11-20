namespace CommandPattern.Utilities
{
    using System.Reflection;
    using System;
    using System.Linq;
    using CommandPattern.Core.Interfaces;

    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string cmdName, string[] args)
        {
            Assembly assembly = Assembly.GetEntryAssembly();
            Type intendedCmdType = assembly.GetTypes().FirstOrDefault(t => t.Name == $"{cmdName}Command");

            if (intendedCmdType == null)
            {
                throw new InvalidOperationException("Invalid command type!");
            }

            MethodInfo executeMethod = intendedCmdType.GetMethods(BindingFlags.Instance | BindingFlags.Public).FirstOrDefault(t => t.Name == "Execute");

            if (executeMethod == null)
            {
                throw new InvalidOperationException("Command does not implement required pattern! Try implementing ICommand interface instead!");
            }

            object instance = Activator.CreateInstance(intendedCmdType);
            string result = (string)executeMethod.Invoke(instance, new object[] { args });

            return result;
        }
    }
}
