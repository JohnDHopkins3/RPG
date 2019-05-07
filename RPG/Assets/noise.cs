using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Noise
{
   public static float[,] GenerateNoiseMap(int mapWidth,int mapHight,float scale)
    {
        float[,] noiseMap = new float[mapWidth, mapHight];

        if (scale<= 0)
        {
            scale = 0.0001f;
        }

        for (int y = 0; y < mapHight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                float sampleX = x / scale;
                float sampleY = y / scale;

                float perlinValue = Mathf.PerlinNoise(sampleX, sampleY);
                noiseMap[x, y] = perlinValue;
            }
        }
        return noiseMap;
    }
}
