﻿using UnityEngine;
using UnityEngine.Networking;

public class PlayerShooter : NetworkBehaviour
{

    private const string PLAYER_TAG = "Player";

    public PlayerWeapon weapon;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private LayerMask mask;

    private void Start()
    {
        if (cam == null)
        {
            Debug.LogError("PlayerShoot: no camera referenced");
            this.enabled = false;
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    [Client]
    void Shoot()
    {
        RaycastHit _hit;
        if (Physics.Raycast(cam.transform.position,cam.transform.forward,out _hit,weapon.range,mask))
        {
            //we hit something
            if (_hit.collider.tag == PLAYER_TAG)
            {
                CmdPlayerShot(_hit.collider.name);
            }
        }
    }

    [Command]
    void CmdPlayerShot(string _ID)
    {
        Debug.Log(_ID + " has been shot.");
    }
}
