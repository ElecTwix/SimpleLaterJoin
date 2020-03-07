using System;
using EXILED;
using EXILED.Extensions;

namespace LaterJoinSimple
{
	public class Plugin : EXILED.Plugin
	{
		//Instance variable for eventhandlers
		public EventHandlers EventHandlers;

        public string Classforrespawn;

        public uint RespawnDuration;

        public override void OnEnable()
		{
			try
			{
				Debug("Laterjoin:Initializing event handlers..");
				//Set instance varible to a new instance, this should be nulled again in OnDisable
				EventHandlers = new EventHandlers(this);
				//Hook the events you will be using in the plugin. You should hook all events you will be using here, all events should be unhooked in OnDisabled 
				Events.PlayerJoinEvent += EventHandlers.OnPlayerJoin;
				Info($"LaterJoinSimple plugin loaded. c:");
			}
			catch (Exception e)
			{
				//This try catch is redundant, as EXILED will throw an error before this block can, but is here as an example of how to handle exceptions/errors
				Error($"LaterjoinSimple There was an error loading the plugin: {e}");
			}
		}

		public override void OnDisable()
		{

            EventHandlers = null;
		}

		public override void OnReload()
		{
            #region Lights Config
            // Text
            Classforrespawn = Config.GetString("Class_forrespawn", "RoleType.ClassD");

            RespawnDuration = Config.GetUInt("respawn_duration", 30);
            #endregion
        }

        public override string getName { get; } = "LaterjoinSimple";
	}
}