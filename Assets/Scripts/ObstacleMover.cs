using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    public static float Speed { get; set; }
    void Start()
    {
        Speed = 10f;
    }

    void Update()
    {
        transform.position+=Vector3.left*Speed*Time.deltaTime;
    }
}//Class