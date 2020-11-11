using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public SpriteRenderer linkSprite = null;
    public Sprite linkHoldSprite = null;
    public GameObject potPosition = null;
    public GameObject PackagePosition = null;
    private Pickupable closestItem = null;
    public bool isHolding = false;
    private PlayerMovement pMove;
    private Sprite linkDefaultSprite = null;

    // Start is called before the first frame update
    void Start()
    {
        pMove = GetComponent<PlayerMovement>();
        linkDefaultSprite = linkSprite.sprite;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //If holding, skip code
        if (isHolding)
        {
            return;
        }
        Pickupable item = collision.collider.GetComponent<Pickupable>();
        if (item != null)
        {
            closestItem = item;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (isHolding)
        {
            return;
        }
        if (collision.collider.GetComponent<Pickupable>() == closestItem)
        {
            closestItem = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //If left click
        if (Input.GetMouseButtonDown(0))
        {
            if (isHolding == false)
            {
                //If touching pickup
                if (closestItem != null)
                {
                    //Put pickup at pot position
                    closestItem.transform.position = potPosition.transform.position;
                    //Set pickup's parent as player
                    closestItem.transform.SetParent(this.transform);
                    isHolding = true;
                    linkSprite.sprite = linkHoldSprite;
                }
            }
            else
            {
                //Remove parent
                closestItem.transform.position = PackagePosition.transform.position;
                isHolding = false;
                linkSprite.sprite = linkDefaultSprite;
                if (pMove.isFacingRight == false)
                {
                    Vector3 newPosition = new Vector3();
                    newPosition = closestItem.transform.localPosition;
                    newPosition.x *= -1;
                    closestItem.transform.localPosition = newPosition;
                }
                closestItem.transform.SetParent(null); 
                closestItem = null;
            }
        }
    }
}
