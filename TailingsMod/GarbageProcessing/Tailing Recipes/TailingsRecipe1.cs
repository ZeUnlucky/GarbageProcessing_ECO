using System;
using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.DynamicValues;
using Eco.Gameplay.Items;
using Eco.Gameplay.Players;
using Eco.Gameplay.Skills;
using Eco.Shared.Utils;
using Eco.World;
using Eco.World.Blocks;
using Eco.Gameplay.Systems.TextLinks;
using Eco.Shared.Localization;
using Eco.Mods.TechTree;

namespace Eco.GarbageProcessing
{

    [RequiresSkill(typeof(TailingRefiningSkill), 3)]
    public partial class RefineTailingsLv1Recipe :
        RecipeFamily
    {
        public RefineTailingsLv1Recipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "RefineTailingsLv1",
                    Localizer.DoStr("Refine Tailings Lv1"),
                    new IngredientElement[]
                    {
               new IngredientElement(typeof(TailingsItem), 6, typeof(TailingRefiningSkill)),
                    },
                    new CraftingElement[]
                    {
               new CraftingElement<CrushedSlagItem>(1),

                    })
            };
            this.ExperienceOnCraft = 0.1f;
            this.LaborInCalories = CreateLaborInCaloriesValue(300, typeof(TailingRefiningSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(RefineTailingsLv1Recipe), 10, typeof(TailingRefiningSkill));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Refine Tailings Lv1"), typeof(RefineTailingsLv1Recipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(RockerBoxObject), this);
        }
        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }
}
