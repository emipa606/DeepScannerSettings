using System.Collections.Generic;
using Verse;

namespace DeepScannerSettings;

public class DSSSettings : ModSettings
{
    public static List<string> DeepOreDefNames = [];
    public static List<float> Commonality = [];
    public static readonly List<float> VanillaCommonality = [];
    public static List<int> MinedAmountPerChunk = [];
    public static readonly List<int> VanillaMinedAmountPerChunk = [];
    public static List<IntRange> VeinSizeRange = [];
    public static readonly List<IntRange> VanillaVeinSizeRange = [];

    public static void ClearSettings()
    {
        DeepOreDefNames.Clear();
        Commonality.Clear();
        MinedAmountPerChunk.Clear();
        VeinSizeRange.Clear();
    }

    public static void ResetToVanilla()
    {
        Commonality = VanillaCommonality.ConvertAll(x => x);
        MinedAmountPerChunk = VanillaMinedAmountPerChunk.ConvertAll(x => x);
        VeinSizeRange = VanillaVeinSizeRange.ConvertAll(x => x);
        DSSMod.UpdateChanges();
    }

    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Collections.Look(ref DeepOreDefNames, "DeepOreDefNames");
        Scribe_Collections.Look(ref Commonality, "Commonality");
        Scribe_Collections.Look(ref MinedAmountPerChunk, "MinedAmountPerChunk");
        Scribe_Collections.Look(ref VeinSizeRange, "VeinSizeRange");
    }
}