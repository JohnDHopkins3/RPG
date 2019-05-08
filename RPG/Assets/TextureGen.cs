using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TextureGen
{
    public static Texture2D TextureFromColorMap(Color[] colorMap,int width,int hight)
    {
        Texture2D texture = new Texture2D(width, hight);
        texture.filterMode = FilterMode.Point;
        texture.wrapMode = TextureWrapMode.Clamp;
        texture.SetPixels(colorMap);
        texture.Apply();
        return texture;
    }

    public static Texture2D TextureFromHightMap(float[,] hightMap)
    {
        int width = hightMap.GetLength(0);
        int height = hightMap.GetLength(1);

        Color[] colorMap = new Color[width * height];
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                colorMap[y * width + x] = Color.Lerp(Color.black, Color.white, hightMap[x, y]);
            }
        }
        return TextureFromColorMap(colorMap,width,height);
    }
}
