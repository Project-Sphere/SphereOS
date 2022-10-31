﻿using Cosmos.System.Network.IPv4.UDP.DNS;
using Cosmos.System.Network.IPv4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThumbOS.Commands.NetworkTopic
{
    internal class Resolve : Command
    {
        public Resolve() : base("resolve")
        {
            Description = "Find the IP of a domain.";

            Topic = "network";
        }

        internal override ReturnCode Execute(string[] args)
        {
            if (args.Length != 2)
            {
                Util.PrintLine(ConsoleColor.Red, "Invalid usage. Please provide a domain.");
                return ReturnCode.Invalid;
            }

            var domain = args[1];

            Util.PrintTask($"Resolving {domain}...");
            using (var dns = new DnsClient())
            {
                dns.Connect(Kernel.DnsAddress);
                dns.SendAsk(domain);

                Address destination = dns.Receive();
                if (destination != null)
                {
                    Util.PrintLine(ConsoleColor.Green, $"{domain} is located at: {destination}");
                }
                else
                {
                    Util.PrintLine(ConsoleColor.Red, $"Unable to resolve {domain}.");
                }
            }

            return ReturnCode.Success;
        }
    }
}
