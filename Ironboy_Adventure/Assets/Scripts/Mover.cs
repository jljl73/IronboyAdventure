using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed = 2.0f;
    public Vector3 Direction = Vector3.forward;

    bool isMoving;

    void Start()
    {
            Move(true);
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.S))
    }

    void FixedUpdate()
    {
        if (isMoving)
            transform.position += (Direction * speed * Time.deltaTime);
    }

    public void Move(bool isMoving)
    {
        this.isMoving = isMoving;
    }
    
    public void SetTarget(GameObject target)
    {
        Direction = target.transform.position - transform.position;
        Debug.Log(Direction);
        Direction = Vector3.Normalize(Direction);
        Debug.Log(Direction);
    }

}
