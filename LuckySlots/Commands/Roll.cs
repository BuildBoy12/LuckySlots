namespace LuckySlots.Commands
{
    using CommandSystem;
    using Exiled.Permissions.Extensions;
    using System;
    using static LuckySlots;
    
    public class Roll : ICommand
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!(sender as CommandSender).CheckPermission("ls.roll"))
            {
                response = "Insufficient permissions. Required: ls.roll";
                return false;
            }

            Instance.Methods.RunSlots();
            response = "Rolling..";
            return true;
        }

        public string Command => "roll";
        public string[] Aliases => Array.Empty<string>();
        public string Description => "Initiates a roll of LuckySlots.";
    }
}