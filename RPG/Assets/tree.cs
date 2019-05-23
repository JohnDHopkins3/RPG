using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tree : MonoBehaviour
{
    public GameObject obj;
   
    private void OnDrawGizmos()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(obj, new Vector3(i, i, i), Quaternion.identity);
        }
    }
}
