using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowPool : MonoBehaviour
{
    public static ShadowPool instance;

    public GameObject shadowPrefab;

    public int shadowCount;

    public Queue availableObjects = new Queue();
    
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        FillPool();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FillPool()
    {
        for (int i = 0; i < shadowCount; i++)
        {
            var newShadow = Instantiate(shadowPrefab);
            newShadow.transform.SetParent(transform);
            
            ReturnPool(newShadow);
        }
    }

    public void ReturnPool(GameObject gameObject)
    {
        gameObject.SetActive(false);
        availableObjects.Enqueue(gameObject);
        
    }

    public GameObject GetFormPool()
    {
        if (availableObjects.Count <= 0)
        {
            FillPool();
        }
        Debug.Log(availableObjects.Count);
        var outShadow = availableObjects.Dequeue() as GameObject;
        Debug.Log(availableObjects.Count);
        outShadow.SetActive(true);
        
        return outShadow;
    }
}
