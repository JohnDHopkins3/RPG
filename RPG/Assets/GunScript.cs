using UnityEngine;

public class GunScript : MonoBehaviour
{

    public float range = 100f;
    public GameObject cube;
    public GameObject sphere;
    public GameObject rectangle;
    public GameObject cylinder;
    public GameObject capsuel;

    GameObject holder;
    public Vector3 offset = new Vector3(1, 1, 1);
    public Camera cam;

    private void Start()
    {
        holder = cube;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Shoot(false,false);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Shoot(false, true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            holder = cube;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            holder = sphere;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            holder = rectangle;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            holder = cylinder;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            holder = capsuel;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot(true,false);
        }
    }
    void Shoot(bool create,bool freze)
    {
        RaycastHit hit;
        
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            if (create == false && freze==true)
            {
                if (hit.collider.gameObject.tag.Equals("object"))
                {
                   Destroy(hit.collider.gameObject.GetComponent<Rigidbody>());
                }
            }
            if (create==true&&freze==false)
            {
                Instantiate(holder, hit.point + offset, Quaternion.identity);
            }
            if (create==false && freze == false)
            {
                if (hit.collider.gameObject.tag.Equals("object"))
                {
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}
