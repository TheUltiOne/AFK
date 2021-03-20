using Exiled.API.Features;
using Exiled.API.Enums;

using Server = Exiled.Events.Handlers.Server;
using Player = Exiled.Events.Handlers.Player;
using Map = Exiled.Events.Handlers.Map;
using System;

namespace AFK
{
    public class AFK : Plugin<Config>
    {
        public override string Name { get; } = "AFKPlugin";
        public override string Author { get; } = "TheUltiOne";
        public override Version Version { get; } = new Version(1, 0, 0);
        public override Version RequiredExiledVersion { get; } = new Version(2, 1, 29);

        private static AFK Singleton = new AFK();

        public override PluginPriority Priority { get; } = PluginPriority.Medium;
        private Handlers.AFKHandlers handlers;

        private AFK()
        {
        }

        public static AFK Instance => Singleton;

        public override void OnEnabled()
        {
            RegisterEvents();
        }

        public override void OnDisabled()
        {
            UnregisterEvents();
        }

        public override void OnReloaded()
        {
            UnregisterEvents();
            RegisterEvents();
        }

        public void RegisterEvents()
        {
            handlers = new Handlers.AFKHandlers();

            Server.RespawningTeam += handlers.OnRespawningTeam;
            Server.RoundEnded += handlers.OnRoundEnded;
        }

        public void UnregisterEvents()
        {
            Server.RespawningTeam -= handlers.OnRespawningTeam;
            Server.RoundEnded -= handlers.OnRoundEnded;
            handlers = null;
        }
    }
}
