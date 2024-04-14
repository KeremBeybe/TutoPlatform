using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBarrýer : MonoBehaviour
{
    public float speed;
    public float rightx;
    public float leftx;

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        if (transform.position.x > leftx)
        {
            speed = -Mathf.Abs(speed);
        }

        else if (transform.position.x < rightx)
        {
            speed = Mathf.Abs(speed);
        }
    }
}
