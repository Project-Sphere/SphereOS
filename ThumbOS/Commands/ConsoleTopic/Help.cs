﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThumbOS.Commands.ConsoleTopic
{
    internal class Help : Command
    {
        public Help() : base("help")
        {
            Description = "Show a list of commands.";

            Topic = "console";
        }

        internal override ReturnCode Execute(string[] args)
        {
            Util.PrintLine(ConsoleColor.Green, "ThumbOS Help");
            Util.Print(ConsoleColor.Cyan, "Select a help topic: ");
            Util.PrintLine(ConsoleColor.White, "console, files, network, power, time, users");

            var topic = Console.ReadLine();
            bool found = false;

            foreach (Command command in CommandManager.commands)
            {
                if (command.Topic == topic)
                {
                    Util.PrintLine(ConsoleColor.White, $"- {command.Name}: {command.Description}");
                    found = true;
                }
            }

            if (!found)
            {
                Util.PrintLine(ConsoleColor.Red, "Unknown help topic.");
                return ReturnCode.Failure;
            }

            return ReturnCode.Success;
        }
    }
}
