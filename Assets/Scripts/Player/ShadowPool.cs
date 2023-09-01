using System.Collections;
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
        var outShadow = availableObjects.Dequeue() as GameObject;
        outShadow.SetActive(true);
        
        return outShadow;
    }
}
