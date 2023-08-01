using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
    private CompositeCollider2D CompositeCollider2D;
    // Start is called before the first frame update
    void Start()
    {
        CompositeCollider2D = GetComponent<CompositeCollider2D>();
    }

    // Update is called once per frame
    void Update()

    {

    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    Debug.Log(collision.GetType().ToString());
    //    Debug.Log(collision.CompareTag("Player"));
    //    if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.C) &&  collision.CompareTag("Player"))
    //    {
    //        Debug.Log("11");
    //        //collision.GetComponent<BoxCollider2D>().isTrigger = true;
    //        //collision.GetComponent<CapsuleCollider2D>().isTrigger = true;
    //        CompositeCollider2D.isTrigger = true;
    //    }
    //}
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetKey(KeyCode.C) && Input.GetKey(KeyCode.DownArrow) && collision.collider.CompareTag("Player"))
        {
            CompositeCollider2D.isTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            //collision.GetComponent<BoxCollider2D>().isTrigger = false;
            //collision.GetComponent<CapsuleCollider2D>().isTrigger = false;
            CompositeCollider2D.isTrigger = false;
        } 
    }


}   

