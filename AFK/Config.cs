using System.ComponentModel;

using Exiled.API.Interfaces;

namespace AFK
{
    public class Config : IConfig
    {
        [Description("Is the plugin enabled?")]
        public bool IsEnabled { get; set; } = true;

        [Description("How many players until the command doesnt work?")]
        public int AFKMaxplayers { get; set; } = 3;

        [Description("The response in console when removed from AFK.")]
        public string RemovedFromAFK { get; set; } = "Removed from AFK!";

        [Description("The response in console when added to AFK.")]
        public string AddedToAFK { get; set; } = "Added to AFK!";

        [Description("Sets the Hint content when the player is not affected by a respawn wave to let them know about their AFK mode.")]
        public string AFKHintContent { get; set; } = "AFK Mode ON ~ To remove it, run .afk in the console. (~/`)";

        [Description("Sets the Hint duration when the player is not affected by a respawn wave.")]
        public float AFKHintDuration { get; set; } = 5;

        [Description("Sets the response sent while trying to use the command but max players are AFK. (use %afkcount% for AFK max players)")]
        public string AFKMaxPlayersMessage { get; set; } = "Max AFK players reached - %afkcount%/%afkcount%";
    }
}
