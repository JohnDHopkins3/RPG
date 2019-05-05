using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour
{
    [SerializeField]
    Behaviour[] componentsToDisable;

    [SerializeField]
    private string remoteLayerName = "RemotePlayer";

    Camera sceneCamera;


    private void Start()
    {
        if (!isLocalPlayer)
        {
            DisableComponents();
            AssingnRemotePlayer();
        }
        else
        {
            sceneCamera = Camera.main;
            if (sceneCamera!=null)
            {
                sceneCamera.gameObject.SetActive(false);
            }
        }
        RegisterPlayer();
    }


    void RegisterPlayer()
    {
        string _ID = "Player " + GetComponent<NetworkIdentity>().netId;
        transform.name = _ID;
    }


    void AssingnRemotePlayer()
    {
        gameObject.layer = LayerMask.NameToLayer(remoteLayerName);
    }


    void DisableComponents()
    {
        for (int i = 0; i < componentsToDisable.Length; i++)
        {
            componentsToDisable[i].enabled = false;
        }
    }


    private void OnDisable()
    {
        if (sceneCamera!=null)
        {
            sceneCamera.gameObject.SetActive(true);
        }
    }
}
