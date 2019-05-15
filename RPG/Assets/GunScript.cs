using UnityEngine;

public class GunScript : MonoBehaviour
{

    public float range = 100f;
    public GameObject cube;
    public Vector3 offset = new Vector3(1, 1, 1);
    public Camera cam;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        RaycastHit hit;
        
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Instantiate(cube,hit.point+offset, Quaternion.identity);
            Debug.Log(hit.transform.name);
        }
    }
}
