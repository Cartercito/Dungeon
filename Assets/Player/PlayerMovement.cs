using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 4;
    private Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newVelocity = new Vector3();
        if (Input.GetKey(KeyCode.S))
        {
            newVelocity.y -= speed;
        }
        if (Input.GetKey(KeyCode.W))
        {
            newVelocity.y += speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            newVelocity.x -= speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            newVelocity.x += speed;
        }
        rigid.velocity = newVelocity;
    }
}
