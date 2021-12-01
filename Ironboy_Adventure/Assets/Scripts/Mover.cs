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
        Direction = Vector3.Normalize(Direction);
    }
    
    public void MulSpeed(float value)
    {
        this.speed *= value;
    }

}
