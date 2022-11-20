﻿using System;
using SphereOS.Shell;

namespace SphereOS.Commands.UsersTopic
{
    internal class Logout : Command
    {
        public Logout() : base("logout")
        {
            Description = "Log out of SphereOS.";

            Topic = "users";
        }

        internal override ReturnCode Execute(string[] args)
        {
            Util.PrintLine(ConsoleColor.Green, "Goodbye!");

            Kernel.CurrentUser = null;
            Shell.Shell.WorkingDir = @"0:\";

            Console.Clear();
            return ReturnCode.Success;
        }
    }
}
