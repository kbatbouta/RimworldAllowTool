﻿using HugsLib.Utils;
using RimWorld;
using Verse;

namespace AllowTool
{
    /// <summary>
    /// A Harvest designator that selects only fully grown plants
    /// </summary>
    public class Designator_HarvestFullyGrown : Designator_SelectableThings
    {
        public Designator_HarvestFullyGrown()
        {
            UseDesignatorDef(AllowToolDefOf.HarvestFullyGrownDesignator);
        }

        public override DesignationDef Designation
        {
            get { return DesignationDefOf.HarvestPlant; }
        }

        public override AcceptanceReport CanDesignateThing(Thing t)
        {
            var plantProps = t?.def.plant;
            var hasHarvestDesgination = t.HasDesignation(Designation);
            return plantProps != null &&
                !hasHarvestDesgination &&
                t is Plant plant &&
                plant.HarvestableNow &&
                plant.LifeStage == PlantLifeStage.Mature &&
                PlantMatchesModifierKeyFilter(plantProps);
        }

        public override void DesignateThing(Thing t)
        {
            if (!CanDesignateThing(t).Accepted) return;
            Map.designationManager.RemoveAllDesignationsOn(t);
            t.ToggleDesignation(Designation, true);
        }

        public override bool RemoveAllDesignationsAffects(LocalTargetInfo target)
        {
            var plantProps = target.Thing.def.plant;
            return plantProps != null && PlantMatchesModifierKeyFilter(plantProps);
        }

        private static bool PlantMatchesModifierKeyFilter(PlantProperties props)
        {
            bool plantIsCrop() => props.harvestTag == "Standard";
            bool plantIsTree() => props.harvestTag == "Wood";
            bool shiftHeld = HugsLibUtility.ShiftIsHeld,
                controlHeld = HugsLibUtility.ControlIsHeld;
            return !shiftHeld && !controlHeld ||
                    shiftHeld && plantIsCrop() ||
                    controlHeld && plantIsTree();

        }
    }
}