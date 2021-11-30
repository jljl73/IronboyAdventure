using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public float length = 100.0f;
    int nSize = 1;

     void Start()
    {
        nSize = transform.parent.childCount;
    }


    void Update()
    {
        if (transform.position.z < -length)
            transform.Translate(new Vector3(0, 0, length * nSize));
    }
}
