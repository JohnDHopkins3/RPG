using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLessTerrain : MonoBehaviour
{
    public const float maxVeiwDst = 300;
    public Transform viewer;

    public static Vector2 viewerPosition;
    int chunkSize;
    int chunkVisibleInViewDst;

    Dictionary<Vector2, TerrainChunk> terrainChunkDictionary = new Dictionary<Vector2, TerrainChunk>();

    private void Start()
    {
        chunkSize = MapGen.mapChunkSize - 1;
        chunkVisibleInViewDst = Mathf.RoundToInt(maxVeiwDst / chunkSize);
    }

    void UpdateVisibleChunks()
    {
        int currentChunkCoordX = Mathf.RoundToInt(viewerPosition.x / chunkSize);
        int currentChunkCoordY = Mathf.RoundToInt(viewerPosition.y / chunkSize);

        for (int yOffset = -chunkVisibleInViewDst; yOffset <= +chunkVisibleInViewDst; yOffset++){
            for (int xOffset = -chunkVisibleInViewDst; xOffset <= +chunkVisibleInViewDst; xOffset++)
            {
                Vector2 viewedChunkCoord = new Vector2(currentChunkCoordX + xOffset, currentChunkCoordY + yOffset);

                if (terrainChunkDictionary.ContainsKey(viewedChunkCoord))
                {

                }
                else
                {
                    terrainChunkDictionary.Add(viewedChunkCoord, new TerrainChunk());
                }
            }
        }
    }

    public class TerrainChunk
    {
        Vector2 position;
        GameObject meshObject;
        Bounds bounds;

        public TerrainChunk(Vector2 coord,int size)
        {
            position = coord * size;
            bounds = new Bounds(position, Vector2.one * size);
            Vector3 positionV3 = new Vector3(position.x, 0, position.y);

            meshObject = GameObject.CreatePrimitive(PrimitiveType.Plane);
            meshObject.transform.position = positionV3;
            meshObject.transform.localScale = Vector3.one * size/10f;
        }

        public void Update()
        {
            float viewerDstFromNearestEdge=Mathf.Sqrt(bounds.SqrDistance(viewerPosition));
            bool visable = viewerDstFromNearestEdge <= maxVeiwDst;
        }
    }
}
