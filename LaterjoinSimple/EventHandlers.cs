using System.Collections.Generic;
using EXILED;
using MEC;
using EXILED.Extensions;

namespace LaterJoinSimple
{
	public class EventHandlers
	{
		public Plugin plugin;
		public EventHandlers(Plugin plugin) => this.plugin = plugin;

        public void OnPlayerJoin(PlayerJoinEvent ev)
        {
            if (RoundSummary.RoundInProgress() && RoundSummary.roundTime < (plugin.RespawnDuration))
            {
                Player.GetPlayer(PlayerManager.localPlayer).characterClassManager.SetPlayersClass((RoleType)System.Enum.Parse(typeof(RoleType), plugin.Classforrespawn), ev.Player.gameObject);
            }
        }


	}
}