using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damage;
    public bool isAttack = false;
    public PolygonCollider2D AttackHitBox;
    private Animator anim;

    void Start()
    {
        AttackHitBox = GetComponent<PolygonCollider2D>();
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    void Update()
    {
        Attack();
    }


    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.X) && !isAttack)
        {
            isAttack = true;
            anim.SetTrigger("Attack");
        }
    }

    public void ExitAttack()
    {
        AttackHitBox.enabled = false;
        isAttack = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
