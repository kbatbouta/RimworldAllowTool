﻿using Verse;

namespace AllowTool.Context
{
    //public class MenuEntry_HaulUrgentVisible : BaseContextMenuEntry {
    //	protected override string BaseTextKey => "Designator_context_urgent_visible";
    //	protected override string BaseMessageKey => "Designator_context_urgent";
    //	protected override string SettingHandleSuffix => "haulUrgentVisible";
    //	protected override ThingRequestGroup DesignationRequestGroup => ThingRequestGroup.HaulableEver;

    //	public override ActivationResult Activate(Designator designator, Map map) {
    //		var visibleRect = AllowToolUtility.GetVisibleMapRect();
    //		var hitCount = DesignateAllThings(designator, map, 
    //			t => MenuEntry_HaulUrgentAll.CanAutoDesignateThingForUrgentHauling(t) && visibleRect.Contains(t.Position));
    //		return hitCount > 0 ?
    //			ActivationResult.Success(BaseTextKey, hitCount) : 
    //			ActivationResult.Failure(BaseMessageKey);
    //	}
    //}
}