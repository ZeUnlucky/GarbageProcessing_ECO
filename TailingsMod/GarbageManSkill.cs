namespace Eco.Mods.TechTree
{
    using System;
    using Eco.Core.Plugins.Interfaces;
    using Eco.Core.Utils;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Gameplay.Systems.Tooltip;
    using Eco.Mods.TechTree;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;


    [Serialized]
    [LocDisplayName("Garbage Handling")]
    public partial class GarbageSkill : Skill
    {


        public static int[] SkillPointCost = { 1, 1, 1, 1, 1 };
        public override int RequiredPoint { get { return this.Level < this.MaxLevel ? SkillPointCost[this.Level] : 0; } }
        public override int PrevRequiredPoint { get { return this.Level - 1 >= 0 && this.Level - 1 < this.MaxLevel ? SkillPointCost[this.Level - 1] : 0; } }
        public override int MaxLevel { get { return 1; } }
    }

    public class ApplyNewRootSkills : IModKitPlugin, IInitializablePlugin
    {
        public string GetStatus()
        {
            return String.Empty;
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

    [Serialized]
    [RequiresSkill(typeof(GarbageSkill), 0)]
    [LocDisplayName("Tailings Processing")]
    public partial class TailingRefiningSkill : Skill
    {
        //you only need to edit this LocString
        public override LocString DisplayDescription { get { return Localizer.DoStr("Give your skill a description"); } }

        public override void OnLevelUp(User user)
        {
            user.Skillset.AddExperience(typeof(SelfImprovementSkill), 20, Localizer.DoStr("for leveling up another specialization."));
        }

        public static MultiplicativeStrategy MultiplicativeStrategy =
           new MultiplicativeStrategy(new float[] {
                1,
                1 - 0.5f,
                1 - 0.55f,
                1 - 0.6f,
                1 - 0.65f,
                1 - 0.7f,
                1 - 0.75f,
                1 - 0.8f,
            });
        public override MultiplicativeStrategy MultiStrategy => MultiplicativeStrategy;
        public static AdditiveStrategy AdditiveStrategy =
            new AdditiveStrategy(new float[] {
                0,
                0.5f,
                0.55f,
                0.6f,
                0.65f,
                0.7f,
                0.75f,
                0.8f,
            });
        public override AdditiveStrategy AddStrategy => AdditiveStrategy;
        public static int[] SkillPointCost = {
            1,
            1,
            1,
            1,
            1,
            1,
            1,
        };
        public override int RequiredPoint { get { return this.Level < SkillPointCost.Length ? SkillPointCost[this.Level] : 0; } }
        public override int PrevRequiredPoint { get { return this.Level - 1 >= 0 && this.Level - 1 < SkillPointCost.Length ? SkillPointCost[this.Level - 1] : 0; } }
        public override int MaxLevel { get { return 7; } }
        public override int Tier { get { return 4; } }
    }
}