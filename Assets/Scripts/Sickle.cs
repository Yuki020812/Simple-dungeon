using System;
using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks.Unity.UnityGameObject;
using UnityEngine;

public class Sickle : MonoBehaviour
{
    public float speed;

    public float rotateSpeed;

    public int damage;

    public float tuning;

    private Rigidbody2D rd;

    private Transform playerTransform;

    private Transform sickleTransform;

    private Vector2 startSpeed;

    private CameraShake camShake;
    
    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        sickleTransform = GetComponent<Transform>();

        rd.velocity = transform.right * speed;  
        startSpeed = rd.velocity;
        camShake = GameObject.FindGameObjectWithTag("CameraShake").GetComponent<CameraShake>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,rotateSpeed);
        float y = Mathf.Lerp(transform.position.y, playerTransform.position.y, tuning);
        transform.position = new Vector3(transform.position.x, y, 0f);
        rd.velocity = rd.velocity - startSpeed * Time.deltaTime;
        
        if (Mathf.Abs(transform.position.x - playerTransform.position.x) < .3f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
