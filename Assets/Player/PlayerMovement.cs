using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 4;
    public float sprintSpeed = 6;
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
            newVelocity.y -= 1;
        }
        if (Input.GetKey(KeyCode.W))
        {
            newVelocity.y += 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            newVelocity.x -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            newVelocity.x += 1;
        }
        //Make unit vector
        newVelocity = newVelocity.normalized;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            newVelocity *= sprintSpeed;
        }
        else
        {
            newVelocity *= speed;
        }
        rigid.velocity = newVelocity;
    }
}
