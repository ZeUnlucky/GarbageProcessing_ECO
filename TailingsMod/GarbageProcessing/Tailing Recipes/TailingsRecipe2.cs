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

    [RequiresSkill(typeof(TailingRefiningSkill), 7)]
    public partial class RefineTailingsLv2Recipe :
        RecipeFamily
    {
        public RefineTailingsLv2Recipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "RefineTailingsLv2",
                    Localizer.DoStr("Refine Tailings Lv2"),
                    new IngredientElement[]
                    {
               new IngredientElement(typeof(TailingsItem), 2, typeof(TailingRefiningSkill)),
                    },
                    new CraftingElement[]
                    {
               new CraftingElement<CrushedSlagItem>(1),

                    })
            };
            this.ExperienceOnCraft = 0.1f;
            this.LaborInCalories = CreateLaborInCaloriesValue(100, typeof(TailingRefiningSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(RefineTailingsLv2Recipe), 4, typeof(TailingRefiningSkill));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Refine Tailings Lv2"), typeof(RefineTailingsLv2Recipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(FrothFloatationCellObject), this);
        }

        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }
}
