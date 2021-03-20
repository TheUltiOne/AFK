using CommandSystem;

using Exiled.API.Features;
using RemoteAdmin;

using System;

using System.Linq;

namespace AFK
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class AFKCommand : ICommand
    {
        public string Command => "afk";

        public string[] Aliases => Array.Empty<string>();

        public string Description => "Gives a player an overwatch-like mode to prevent AFK kicking";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (sender is PlayerCommandSender player)
            {
                if (Handlers.AFKHandlers.afk_players.Count() >= AFK.Instance.Config.AFKMaxplayers)
                {
                    response = AFK.Instance.Config.AFKMaxPlayersMessage.Replace("%afkcount%", Convert.ToString(AFK.Instance.Config.AFKMaxplayers)); ;
                    return false;
                }

                Player p = Player.Get(player.SenderId);

                if (Handlers.AFKHandlers.afk_players.Contains(p)) {
                    Handlers.AFKHandlers.afk_players.Remove(p);
                } else
                {
                    Handlers.AFKHandlers.afk_players.Add(p);
                }

                response = Handlers.AFKHandlers.afk_players.Contains(p)
                    ? AFK.Instance.Config.RemovedFromAFK
                    : AFK.Instance.Config.AddedToAFK;
                return true;
            }

            response = "This command must be executed from the game level.";
            return false;
        }
    }
}
