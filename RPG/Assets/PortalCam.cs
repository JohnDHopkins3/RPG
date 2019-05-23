using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCam : MonoBehaviour
{
    public Transform playerCam;
    public Transform portal;
    public Transform otherPortal;


    // Update is called once per frame
    void Update()
    {
        Vector3 playerOffsetFromPortal = playerCam.position - otherPortal.position;
        transform.position = portal.position + playerOffsetFromPortal;

        float angularDifferenceBetweenPortalRotations = Quaternion.Angle(portal.rotation,otherPortal.rotation);

        Quaternion portalRotationalDiference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
        Vector3 newCamDirection = portalRotationalDiference * playerCam.forward;
        transform.rotation = Quaternion.LookRotation(newCamDirection, Vector3.up);
    }
}
