using Eco.Core.Plugins;
using Eco.Core.Plugins.Interfaces;
using Eco.Core.Utils;
using Eco.Gameplay.Players;
using Eco.Shared.Localization;
using Eco.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eco.GarbageProcessing
{
    class GarbageModInit : IModKitPlugin, IInitializablePlugin
    {
        public string GetStatus()
        {
            return "Running";
        }

        public void Initialize(TimedTask timer)
        {
            UserManager.OnUserLoggedIn.Add(u =>
            {
                if (!u.Skillset.HasSkill(typeof(GarbageSkill)))
                    u.Skillset.LearnSkill(typeof(GarbageSkill));
            });
        }
    }
}
