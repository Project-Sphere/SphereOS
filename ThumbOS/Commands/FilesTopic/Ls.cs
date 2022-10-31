﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThumbOS.Commands.FilesTopic
{
    internal class Ls : Command
    {
        public Ls() : base("ls")
        {
            Description = "List files and directories.";

            Topic = "files";
        }

        internal override ReturnCode Execute(string[] args)
        {
            foreach (var file in Directory.GetFiles(Kernel.WorkingDir))
            {
                Util.Print(ConsoleColor.Cyan, Path.GetFileName(file) + " ");
            }
            foreach (var dir in Directory.GetDirectories(Kernel.WorkingDir))
            {
                Util.Print(ConsoleColor.Green, Path.GetFileName(dir) + " ");
            }
            Console.WriteLine();
            return ReturnCode.Success;
        }
    }
}
