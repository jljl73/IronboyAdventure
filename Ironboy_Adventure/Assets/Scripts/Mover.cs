using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed = 2.0f;
    public Vector3 Direction = new Vector3(0, 0, -1);

    public int width = 1;
    public int Width { get => width; }
    bool isMoving;
    
    void Start()
    {
        Move(true);
    }
    
    void FixedUpdate()
    {
        if (GameManager.Instance.BossMode && transform.tag != "Enemy")
            return;

        if (isMoving && !GameManager.Instance.GameOver)
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
