﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public GameObject potPosition = null;
    private Pickupable closestItem = null;
    private bool isHolding = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
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
                }
            }
            else
            {
                //Remove parent
                closestItem.transform.SetParent(null);
                isHolding = false;
                closestItem = null;
            }
        }
    }
}