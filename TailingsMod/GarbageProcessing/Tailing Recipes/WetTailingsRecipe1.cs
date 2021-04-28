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
    [RequiresSkill(typeof(TailingRefiningSkill), 1)] 
    public partial class RefineWetTailingsLv1Recipe :
        RecipeFamily
    {
        public RefineWetTailingsLv1Recipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "RefineWetTailingsLv1",
                    Localizer.DoStr("Refine Wet Tailings Lv1"),
                    new IngredientElement[]
                    {
               new IngredientElement(typeof(WetTailingsItem), 20, typeof(TailingRefiningSkill)),  
                    },
                    new CraftingElement[]
                    {
               new CraftingElement<TailingsItem>(2),   
    
                    })
            };
            this.ExperienceOnCraft = 0.1f;  
            this.LaborInCalories = CreateLaborInCaloriesValue(100, typeof(TailingRefiningSkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(RefineWetTailingsLv1Recipe), 10, typeof(TailingRefiningSkill));     
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Refine Wet Tailings Lv1"), typeof(RefineWetTailingsLv1Recipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(BloomeryObject), this);
        }

        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }
}
