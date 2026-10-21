using Mlie;
using UnityEngine;
using Verse;

namespace DeepScannerSettings;

public class DSSMod : Mod
{
    private static string currentVersion;
    private Vector2 scrollPosition;

    private DSSSettings settings;

    public DSSMod(ModContentPack con) : base(con)
    {
        settings = GetSettings<DSSSettings>();
        currentVersion = VersionFromManifest.GetVersionFromModMetaData(con.ModMetaData);
    }

    public override void DoSettingsWindowContents(Rect inRect)
    {
        const float addHeight = 25f;

        if (Widgets.ButtonText(new Rect(inRect.x + (inRect.width - 100f), inRect.y, 100f, 20f),
                "DSS.reset".Translate()))
        {
            DSSSettings.ResetToVanilla();
        }

        if (currentVersion != null)
        {
            GUI.contentColor = Color.gray;
            Widgets.Label(new Rect(inRect.x, inRect.y, inRect.width, 20f),
                "DSS.currentversion".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        var borderRect = inRect;
        borderRect.y += addHeight;
        borderRect.height -= addHeight;
        var scrollContentRect = inRect;
        scrollContentRect.height = DSSSettings.DeepOreDefNames.Count * 220f;
        scrollContentRect.width -= 20;
        scrollContentRect.x = 0;
        scrollContentRect.y = 0;

        var lister = new Listing_Standard();
        Widgets.BeginScrollView(borderRect, ref scrollPosition, scrollContentRect);

        lister.Begin(scrollContentRect);
        lister.Gap();

        for (var i = 0; i < DSSSettings.DeepOreDefNames.Count; ++i)
        {
            var oreLabel = ThingDef.Named(DSSSettings.DeepOreDefNames[i]).label;

            lister.Settings_Header(Utils.StringToTitleCase(oreLabel), Color.clear);
            lister.GapLine();

            var c = DSSSettings.Commonality[i];
            var m = DSSSettings.MinedAmountPerChunk[i];
            var r1 = DSSSettings.VeinSizeRange[i].min;
            var r2 = DSSSettings.VeinSizeRange[i].max;

            lister.Settings_Numericbox("DSSCommonality".Translate() + " " + oreLabel, ref c, 320, 12f);
            lister.Settings_IntegerBox("DSSMinedAmountPerChunk".Translate(), ref m, 320, 12);
            lister.Settings_IntegerBox("DSSVeinSizeRangeMin".Translate(), ref r1, 320, 12f);
            lister.Settings_IntegerBox("DSSVeinSizeRangeMax".Translate(), ref r2, 320, 12f);

            DSSSettings.Commonality[i] = c;
            DSSSettings.MinedAmountPerChunk[i] = m;
            DSSSettings.VeinSizeRange[i] = new IntRange(r1, r2);

            lister.Gap(32f);
        }

        lister.End();
        Widgets.EndScrollView();

        base.DoSettingsWindowContents(inRect);
    }

    public override void WriteSettings()
    {
        UpdateChanges();

        base.WriteSettings();
    }

    public override string SettingsCategory()
    {
        return "DSSMenuTitle".Translate();
    }

    public static void UpdateChanges()
    {
        if (!DSSSettings.DeepOreDefNames.Any())
        {
            return;
        }

        for (var i = 0; i < DSSSettings.DeepOreDefNames.Count; ++i)
        {
            var oreDef = ThingDef.Named(DSSSettings.DeepOreDefNames[i]);
            oreDef.deepCommonality = DSSSettings.Commonality[i];
            oreDef.deepCountPerPortion = DSSSettings.MinedAmountPerChunk[i];
            oreDef.deepLumpSizeRange = DSSSettings.VeinSizeRange[i];
        }
    }
}