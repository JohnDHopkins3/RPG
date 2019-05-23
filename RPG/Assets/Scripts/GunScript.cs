using UnityEngine;

public class GunScript : MonoBehaviour
{

    public float range = 100f;
    public GameObject cube;
    public GameObject sphere;
    public GameObject rectangle;
    public GameObject cylinder;
    public GameObject capsuel;
    public GameObject tree;
    bool froze = false;

    GameObject holder;
    public Vector3 offset;
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
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            holder = tree;
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
                    if (froze == false)
                    {
                        hit.collider.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                        froze = true;
                    }
                    else
                    {
                        hit.collider.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                        froze = false;
                    }
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
