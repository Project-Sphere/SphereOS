﻿using SphereOS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SphereOS.Commands.ConsoleTopic
{
    internal class Lsproc : Command
    {
        public Lsproc() : base("lsproc")
        {
            Description = "List all processes.";

            Topic = "console";
        }

        internal override ReturnCode Execute(string[] args)
        {
            var id = new List<string>() { "ID" };
            var name = new List<string>() { "Name" };
            var type = new List<string>() { "Type" };
            var running = new List<string>() { "Running" };
            var parent = new List<string>() { "Parent" };
            var time = new List<string>() { "Time" };

            var columns = new List<List<string>>()
            {
                id,
                name,
                type,
                running,
                parent,
                time
            };

            foreach (var process in ProcessManager.Processes)
            {
                // ID
                id.Add(process.Id.ToString());

                // Name
                name.Add(process.Name);

                // Type
                switch (process.Type)
                {
                    case ProcessType.Application:
                        type.Add("Application");
                        break;
                    case ProcessType.Service:
                        type.Add("Service");
                        break;
                    default:
                        type.Add(string.Empty);
                        break;
                }

                // Running
                running.Add(process.IsRunning.ToString());

                // Parent
                if (process.Parent != null)
                {
                    parent.Add(process.Parent.Id.ToString());
                }
                else
                {
                    parent.Add(string.Empty);
                }
                
                // Time
                time.Add((DateTime.Now - process.Created).ToString());
            }

            Util.PrintLine(ConsoleColor.Gray, $"{ProcessManager.Processes.Count} total processes");

            Util.PrintTable(columns, color: ConsoleColor.White, headerColour: ConsoleColor.Cyan);

            return ReturnCode.Success;
        }
    }
}
