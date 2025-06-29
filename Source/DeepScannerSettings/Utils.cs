using UnityEngine;
using Verse;

namespace DeepScannerSettings;

[StaticConstructorOnStartup]
public static class Utils
{
    private static readonly Color textColor = Color.white;

    public static void Settings_IntegerBox(this Listing_Standard lister, string text, ref int value, float labelLength,
        float padding, int min = int.MinValue, int max = int.MaxValue)
    {
        lister.Gap();
        var rect = lister.GetRect(Text.LineHeight);

        var rectLeft = new Rect(rect.x, rect.y, labelLength, rect.height);
        var rectRight = new Rect(rect.x + labelLength + padding, rect.y, rect.width - labelLength - padding,
            rect.height);

        var color = GUI.color;
        Widgets.Label(rectLeft, text);

        var align = Text.CurTextFieldStyle.alignment;
        Text.CurTextFieldStyle.alignment = TextAnchor.MiddleLeft;
        var buffer = value.ToString();
        Widgets.TextFieldNumeric(rectRight, ref value, ref buffer, min, max);

        Text.CurTextFieldStyle.alignment = align;
        GUI.color = color;
    }

    public static void Settings_Numericbox(this Listing_Standard lister, string text, ref float value,
        float labelLength, float padding, float min = -1E+09f, float max = 1E+09f)
    {
        lister.Gap();
        var rect = lister.GetRect(Text.LineHeight);

        var rectLeft = new Rect(rect.x, rect.y, labelLength, rect.height);
        var rectRight = new Rect(rect.x + labelLength + padding, rect.y, rect.width - labelLength - padding,
            rect.height);

        var color = GUI.color;
        Widgets.Label(rectLeft, text);

        var align = Text.CurTextFieldStyle.alignment;
        Text.CurTextFieldStyle.alignment = TextAnchor.MiddleLeft;
        var buffer = value.ToString();
        Widgets.TextFieldNumeric(rectRight, ref value, ref buffer, min, max);

        Text.CurTextFieldStyle.alignment = align;
        GUI.color = color;
    }

    public static void Settings_Header(this Listing_Standard lister, string header, Color highlight,
        GameFont fontSize = GameFont.Medium, TextAnchor anchor = TextAnchor.MiddleLeft)
    {
        var textSize = Text.Font;
        Text.Font = fontSize;

        var rect = lister.GetRect(Text.CalcHeight(header, lister.ColumnWidth));
        GUI.color = highlight;
        GUI.DrawTexture(rect, BaseContent.WhiteTex);
        GUI.color = textColor;

        var anchorTmp = Text.Anchor;
        Text.Anchor = anchor;
        Widgets.Label(rect, header);
        Text.Font = textSize;
        Text.Anchor = anchorTmp;
        lister.Gap();
    }

    public static string StringToTitleCase(string text)
    {
        return text.Length switch
        {
            1 => text.ToUpper(), > 1 => char.ToUpper(text[0]) + text[1..], _ => text
        };
    }
}