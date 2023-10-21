using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_Door : MonoBehaviour
{
    public GameObject[] doors;
    public bool check_oneobj; //If there's just one obj

    private void Start()
    {
        if(check_oneobj is true)
        {
            doors[0].SetActive(true);
        }
        else
        {
            activate(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag =="Player")
        {
            activate(true);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            activate(false);

        }
    }

    
    public void activate(bool check)
    {
        if(check is true)
        {
            if(check_oneobj is true)
            {
                doors[0].SetActive(false);

            }
            else
            {
                doors[0].SetActive(true);
                doors[1].SetActive(false);
            }
            
        }
        else
        {
            if(check_oneobj is true)
            {
                doors[0].SetActive(true);
            }
            else
            {
                doors[0].SetActive(false);
                doors[1].SetActive(true);
            }            
        }
    }

}
