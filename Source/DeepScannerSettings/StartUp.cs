using System.Linq;
using Verse;

namespace DeepScannerSettings;

[StaticConstructorOnStartup]
public static class StartUp
{
    static StartUp()
    {
        // Loads right before main menu
        SetOriginalValues();

        DSSMod.UpdateChanges();
    }

    public static void SetOriginalValues()
    {
        var oreList = DefDatabase<ThingDef>.AllDefs.Where(o => o.deepCommonality > 0).ToList();

        if (oreList.Count != DSSSettings.Commonality.Count || oreList.Count != DSSSettings.MinedAmountPerChunk.Count ||
            oreList.Count != DSSSettings.VeinSizeRange.Count)
        {
            Log.Warning("WarningSettingsMismatchReset".Translate());
            DSSSettings.ClearSettings();
        }

        if (oreList.Count < DSSSettings.DeepOreDefNames.Count)
        {
            Log.Warning("WarningLostOresReset".Translate());
            DSSSettings.ClearSettings();
        }

        if (oreList.Count <= 0)
        {
            return;
        }

        foreach (var thingDef in oreList)
        {
            DSSSettings.VanillaCommonality.Add(thingDef.deepCommonality);
            DSSSettings.VanillaMinedAmountPerChunk.Add(thingDef.deepCountPerPortion);
            DSSSettings.VanillaVeinSizeRange.Add(thingDef.deepLumpSizeRange);

            if (DSSSettings.DeepOreDefNames.Contains(thingDef.defName))
            {
                continue;
            }

            DSSSettings.DeepOreDefNames.Add(thingDef.defName);
            DSSSettings.Commonality.Add(thingDef.deepCommonality);
            DSSSettings.MinedAmountPerChunk.Add(thingDef.deepCountPerPortion);
            DSSSettings.VeinSizeRange.Add(thingDef.deepLumpSizeRange);
        }
    }
}