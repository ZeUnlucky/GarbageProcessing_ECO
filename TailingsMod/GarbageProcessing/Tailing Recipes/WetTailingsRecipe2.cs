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
    [RequiresSkill(typeof(TailingRefiningSkill), 5)] 
    public partial class RefineWetTailingsLv2Recipe :
        RecipeFamily
    {
        public RefineWetTailingsLv2Recipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "RefineWetTailingsLv2",
                    Localizer.DoStr("Refine Wet Tailings Lv2"),
                    new IngredientElement[]
                    {
               new IngredientElement(typeof(WetTailingsItem), 8, typeof(TailingRefiningSkill)),  
                    },
                    new CraftingElement[]
                    {
               new CraftingElement<TailingsItem>(2),   
    
                    })
            };
            this.ExperienceOnCraft = 0.1f;  
            this.LaborInCalories = CreateLaborInCaloriesValue(200, typeof(TailingRefiningSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(RefineWetTailingsLv2Recipe), 3, typeof(TailingRefiningSkill));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Refine Wet Tailings Lv2"), typeof(RefineWetTailingsLv2Recipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(BlastFurnaceObject), this);
        }

        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }
}
