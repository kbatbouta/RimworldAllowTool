using RimWorld.Planet;
using Verse;

namespace AllowTool.Settings
{
    /// <summary>
    /// Store settings for a specific world save file
    /// </summary>
    public class WorldSettings : WorldComponent
    {
        private StripMineWorldSettings stripMine;
        public StripMineWorldSettings StripMine
        {
            get { return stripMine ?? (stripMine = new StripMineWorldSettings()); }
            set { stripMine = value; }
        }

        public override void ExposeData()
        {
            Scribe_Deep.Look(ref stripMine, "stripMine");
        }

        public WorldSettings(World world) : base(world)
        {
        }
    }
}