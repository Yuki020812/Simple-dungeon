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
    public GameObject bloodEffect;
    public GameObject dropItem;
    public GameObject floatPoint;
    private PlayerHealth playerHealth;
    private FloatPointController fpc;
    // Start is called before the first frame update
    public virtual void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        originColor = spriteRender.color;
        fpc = FindObjectOfType<FloatPointController>().GetComponent<FloatPointController>();
    }

    // Update is called once per frame
    public virtual void Update()
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
        fpc.ShowDamage(damage, transform.position);
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
