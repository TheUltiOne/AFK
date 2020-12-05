using CommandSystem;
using Exiled.API.Features;
using RemoteAdmin;
using System;
using System.Linq;

namespace AFK
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class AfkCmd : ICommand
    {
        public string Command => "afk";

        public string[] Aliases => Array.Empty<string>();

        public string Description => "Gives a player overwatch mode to prevent afk kicking";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (sender is PlayerCommandSender player)
            {
                Player p = Player.Get(player.SenderId);
                if (Handlers.Server.afk_players.Contains(p) == true) {
                    Handlers.Server.afk_players.Add(p);
                } else
                {
                    Handlers.Server.afk_players.Remove(p);

                }
                response = Handlers.Server.afk_players.Contains(p)
                    ? AFK.Instance.Config.AddedToAFK
                    : AFK.Instance.Config.RemovedFromAFK;
                return true;
            }
            if (Handlers.Server.afk_players.Count() >= AFK.Instance.Config.Maxplayers)
            {
                response = "Too many players";
                return false;
            }

            response = "This command must be executed from the game level.";
            return false;
        }
    }
}
