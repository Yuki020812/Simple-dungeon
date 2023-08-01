using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int hp;
    public int damage;
    private SpriteRenderer spriteRender;
    private Color originColor;
    public float flashTime;
    private PlayerHealth playerHealth;
    public GameObject bloodEffect;
    public GameObject dropItem;
    // Start is called before the first frame update
    public void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        originColor = spriteRender.color;
    }

    // Update is called once per frame
    public void Update()
    {
        if (hp <= 0)
        {
            Instantiate(dropItem,transform.position,Quaternion.identity);
            Destroy(transform.gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        ChangeColor(flashTime);
        Instantiate(bloodEffect,transform.position,Quaternion.identity);
        GameController.camShake.Shake();
    }

    public void ChangeColor(float time)
    {
        spriteRender.color = Color.red;
        Invoke("ResetColor", time);
    }

    public void ResetColor()
    {
        spriteRender.color = originColor;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            if (playerHealth != null)
            {
                playerHealth.HitPlayer(damage);
            }
        }
    }
}
