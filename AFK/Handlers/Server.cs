using System;
using Exiled.Events.EventArgs;
using EPlayer = Exiled.API.Features.Player;
using System.Collections.Generic;

namespace AFK.Handlers
{
    class Server
    {
        public static List<EPlayer> afk_players = new List<EPlayer>();

        public void OnRespawningTeam(RespawningTeamEventArgs ev)
        {
            foreach (EPlayer player in EPlayer.List)
            {
                if (afk_players.Contains(player))
                {
                    ev.Players.Remove(player);
                }
            }
        }
    }
}
