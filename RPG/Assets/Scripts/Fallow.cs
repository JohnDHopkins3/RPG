using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fallow : MonoBehaviour
{
    Transform Player;
    public float speed = 2f;
    private void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Player.position, speed);
    }
}
