using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern.Core.Contracts
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] rrr =  args.Split(' ');
            Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == rrr[0] + "Command");
            if (type == default) throw new ArgumentException("Invalid op");
            var instance = Activator.CreateInstance(type) as ICommand;
            rrr = args.Split(' ').Skip(1).ToArray();
            return instance.Execute(rrr);
        }
    }
}
