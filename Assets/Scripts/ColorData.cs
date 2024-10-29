using UnityEngine;

public class ColorData
{
    public Color[] mainColor;
    public Color[] subColor;

    public int maxColorNum;

    private string[,] colors;

    public void Initialize()
    {
        colors = new string[10, 3] {
            { "#FFF100" , "#4C4CFF" , "Inksible" },
            { "#FF3399" , "#FF00FF" , "Shiga" },
            { "#2BE3BD" , "#073F6F" , "Minty" },
            { "#AA0622" , "#E4D1A9" , "R&W" },
            { "#8BAC0F" , "#306230" , "GameBoy" },
            { "#B8A3F0" , "#4B306C" , "Chill" },
            { "#D3B839" , "#28063A" , "Moon" },
            { "#EC6610" , "#39302C" , "SunSet" },
            { "#614942" , "#D29C6E" , "Chocolate" },
            { "#909090" , "#202020" , "Monochrome" }
        };

        maxColorNum = colors.GetLength(0);

        mainColor = new Color[maxColorNum];
        subColor = new Color[maxColorNum];
        for (int i = 0; i < maxColorNum; i++)
        {
            ColorUtility.TryParseHtmlString(colors[i, 0], out mainColor[i]);
            ColorUtility.TryParseHtmlString(colors[i, 1], out subColor[i]);
        }
    }

    public Color GetMainColor(int _num)
    {
        return mainColor[_num];
    }
    public Color GetSubColor(int _num)
    {
        return subColor[_num];
    }
}