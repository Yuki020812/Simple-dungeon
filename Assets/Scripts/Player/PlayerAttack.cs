using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damage;
    public bool isAttack = false;
<<<<<<< HEAD:Assets/Scripts/Player/PlayerAttack.cs
    public PolygonCollider2D attackHitBox;
=======
    public PolygonCollider2D AttackHitBox;
>>>>>>> 0887a4aff6410cfdee15a76485c274c1a6b5c839:Assets/Scripts/PlayerAttack.cs
    public Animator anim;

    void Start()
    {
        attackHitBox = GetComponent<PolygonCollider2D>();
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
            SoundManager.Attack();
            anim.SetTrigger("Attack");
        }
    }

    public void ExitAttack()
    {
        attackHitBox.enabled = false;
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
