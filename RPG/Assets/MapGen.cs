using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGen : MonoBehaviour
{
    public enum DrawMode {NoiseMap, ColorMap, Mesh};
    public DrawMode drawMode;

    public int mapWidth;
    public int mapHight;
    public float noiseScale;

    public int octaves;
    [Range(0,1)]
    public float persistance;
    public float lacunarity;

    public int seed;
    public Vector2 offset;

    public bool autoUpdate;

    public TerrainType[] regions;

    public void GenerateMap()
    {
        float[,] noiseMap = Noise.GenerateNoiseMap(mapWidth, mapHight, seed, noiseScale, octaves, persistance, lacunarity, offset);

        Color[] colorMap = new Color[mapWidth * mapHight];
        for (int y = 0; y < mapHight; y++){
            for (int x = 0; x < mapWidth; x++)
            {
                float currentHight = noiseMap[x, y];
                for (int i = 0; i < regions.Length; i++)
                {
                    if (currentHight<=regions [i].hight)
                    {
                        colorMap[y * mapWidth + x]=regions[i].color;
                        break;
                    }
                }
            }
        }

        MapDisplay display = FindObjectOfType<MapDisplay>();
        if (drawMode==DrawMode.NoiseMap)
        {
            display.DrawTexture(TextureGen.TextureFromHightMap(noiseMap));
        }
        else if (drawMode==DrawMode.ColorMap)
        {
            display.DrawTexture(TextureGen.TextureFromColorMap(colorMap,mapWidth,mapHight));
        }
        else if (drawMode==DrawMode.Mesh)
        {
            display.DrawMesh(MeshGen.GenTurrainMesh(noiseMap), TextureGen.TextureFromColorMap(colorMap, mapWidth, mapHight));
        }
    }

    private void OnValidate()
    {
        if (mapWidth<1)
        {
            mapWidth = 1;
        }
        if (mapHight<1)
        {
            mapHight = 1;
        }
        if (lacunarity<1)
        {
            lacunarity = 1;
        }
        if (octaves<0)
        {
            octaves = 0;
        }
    }
}
[System.Serializable]
public struct TerrainType
{
    public string name;
    public float hight;
    public Color color;
}
