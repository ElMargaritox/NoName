using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger = Rocket.Core.Logging.Logger;
using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Steamworks;
using System.Reflection;
using Rocket.API;

namespace NoName
{
    public class Class1 : RocketPlugin
    {
        protected override void Load()
        {
            U.Events.OnPlayerConnected += Conectado;
            Logger.Log("Se Ha Deshabilitado Correctamente Que No Muestre Los Nombres", ConsoleColor.Yellow);
        }


        private void Conectado(UnturnedPlayer player)
        {
            if (player.IsAdmin)
            {
                player.Player.enablePluginWidgetFlag(SDG.Unturned.EPluginWidgetFlags.ShowInteractWithEnemy);
            }
            else if (player.HasPermission("noname.bypass"))
            {
                player.Player.enablePluginWidgetFlag(SDG.Unturned.EPluginWidgetFlags.ShowInteractWithEnemy);
            }
            else
            {
                player.Player.disablePluginWidgetFlag(SDG.Unturned.EPluginWidgetFlags.ShowInteractWithEnemy);
            }

        }

        protected override void Unload()
        {
            base.Unload();
            base.UnloadPlugin();
        }
    }
}
