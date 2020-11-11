using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public SpriteRenderer linkSprite = null;
    public Sprite playerUpOne = null;
    public Sprite playerLeftOne = null;
    public Sprite playerRightOne = null;
    public Sprite playerIdle = null;
    public bool isFacingRight = false;
    public float speed = 4;
    public float sprintSpeed = 6;
    private Rigidbody2D rigid;
    private PlayerPickup pickup;

    // Start is called before the first frame update
    void Start()
    {
        pickup = GetComponent<PlayerPickup>();
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Sprite movesprite = playerIdle;
        
        Vector3 newVelocity = new Vector3();
        if (Input.GetKey(KeyCode.S))
        {
            newVelocity.y -= 1;
        }
        if (Input.GetKey(KeyCode.W))
        {
            newVelocity.y += 1;
            movesprite = playerUpOne;
        }
        if (Input.GetKey(KeyCode.A))
        {
            newVelocity.x -= 1;
            movesprite = playerLeftOne;
            isFacingRight = false;
        }
        if (Input.GetKey(KeyCode.D))
        {
            newVelocity.x += 1;
            movesprite = playerRightOne;
            isFacingRight = true;
        }
        //Make unit vector
        newVelocity = newVelocity.normalized;
        if (pickup.isHolding == false)
        {
            linkSprite.sprite = movesprite;
        }
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
