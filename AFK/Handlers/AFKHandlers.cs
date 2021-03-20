using System.Collections.Generic;
using Exiled.API.Features;
using Exiled.Events.EventArgs;

namespace AFK.Handlers
{
    class AFKHandlers
    {
        public static List<Player> afk_players = new List<Player>();
        
        public void OnRoundEnded(RoundEndedEventArgs ev) {
            afk_players.Clear();
        }

        public void OnRespawningTeam(RespawningTeamEventArgs ev)
        {
            foreach (Player i in ev.Players)
            {
                if (afk_players.Contains(i))
                {
                    ev.Players.Remove(i);
                    i.ShowHint(AFK.Instance.Config.AFKHintContent, AFK.Instance.Config.AFKHintDuration);
                }
            }
        }
    }
}
