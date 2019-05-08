using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Noise
{
   public static float[,] GenerateNoiseMap(int mapWidth,int mapHight,int seed,float scale,int octaves,float persistance,float lacunarity,Vector2 offset)
    {
        float[,] noiseMap = new float[mapWidth, mapHight];

        System.Random prng = new System.Random(seed);
        Vector2[] octavesOffset = new Vector2[octaves];
        for (int i = 0; i < octaves; i++)
        {
            float offsetX = prng.Next(-100000,100000)+offset.x;
            float offsetY = prng.Next(-100000,100000)+offset.y;
            octavesOffset[i] = new Vector2(offsetX, offsetY);
        }

        if (scale<= 0)
        {
            scale = 0.0001f;
        }

        float maxNoiseHight = float.MinValue;
        float minNoiseHight = float.MaxValue;

        float halfWidth = mapWidth / 2f;
        float halfHight = mapHight / 2f;

        for (int y = 0; y < mapHight; y++){
            for (int x = 0; x < mapWidth; x++)
            {
                float amplitude = 1;
                float frequency = 1;
                float noiseHight = 0;

                for (int i = 0; i < octaves; i++)
                {
                    float sampleX = (x-halfWidth) / scale * frequency+octavesOffset[i].x;
                    float sampleY = (y-halfHight) / scale * frequency+octavesOffset[i].y;

                    float perlinValue = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1;
                    noiseHight += perlinValue * amplitude;

                    amplitude *= persistance;
                    frequency *= lacunarity;
                }

                if (noiseHight>maxNoiseHight)
                {
                    maxNoiseHight = noiseHight;
                }
                else if (noiseHight<minNoiseHight)
                {
                    minNoiseHight = noiseHight;
                }
                noiseMap[x, y] = noiseHight;
            }
        }

        for (int y = 0; y < mapHight; y++){
            for (int x = 0; x < mapWidth; x++)
            {
                noiseMap[x, y] = Mathf.InverseLerp(minNoiseHight, maxNoiseHight, noiseMap[x, y]);
            }
        }
                return noiseMap;
    }
}
