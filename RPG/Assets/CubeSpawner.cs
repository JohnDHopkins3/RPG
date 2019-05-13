using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject gameObject;
    
    public Vector3 sizeIncrease=new Vector3(1,1,1);
    public Vector3 offset;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Comma))
        {
            gameObject.transform.localScale += sizeIncrease;
        }
        if (Input.GetKeyDown(KeyCode.Period))
        {
            gameObject.transform.localScale -= sizeIncrease;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(gameObject, transform.position+offset, Quaternion.identity);
        }
        gameObject.transform.localScale = sizeIncrease;
    }
}
