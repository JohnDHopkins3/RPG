using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetup : MonoBehaviour
{
    public Camera camA;
    public Camera camB;
    public Material cameraMatB;
    public Material cameraMatA;

    void Start()
    {
        if (camB.targetTexture!=null)
        {
            camB.targetTexture.Release();
        }
        camB.targetTexture = new RenderTexture(Screen.width,Screen.height,24);
        cameraMatB.mainTexture = camB.targetTexture;

        if (camA.targetTexture != null)
        {
            camA.targetTexture.Release();
        }
        camA.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMatA.mainTexture = camA.targetTexture;
    }

}
