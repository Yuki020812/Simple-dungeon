using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SicklePool : MonoBehaviour
{
    public static SicklePool instance;
    public GameObject sicklePrefab;
    public int sickleCount;
    public Queue sickleObjects = new Queue();

    public GameObject sicklePosition;
    // Start is called before the first frame update
    void Awake()
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
        for (int i = 0; i < sickleCount; i++)
        {
            var newSickle = Instantiate(sicklePrefab);
            newSickle.transform.SetParent(transform);
            ReturnPool(newSickle);
        }
    }

    public void ReturnPool(GameObject gameObject)
    {
        gameObject.SetActive(false);
        sickleObjects.Enqueue(gameObject);
    }

    public GameObject GetFormPool()
    {
        if (sickleObjects.Count <= 0)
        {
            FillPool();
        }
        var outSickle = sickleObjects.Dequeue() as GameObject;
        outSickle.SetActive(true);

        return outSickle;
    }
    
}
