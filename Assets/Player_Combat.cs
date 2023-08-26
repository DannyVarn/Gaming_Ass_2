using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Combat : MonoBehaviour
{
    public Animator animator;
    public Transform attack_point;
    public float attack_range = 20f;
    public LayerMask enemyLayer;

    public float attackspeed = 2f;

    private float NextFire;

    public int Damage=25;



    void Update()
    {
        if (Input.GetMouseButtonDown(0)&& Time.time>NextFire){
            NextFire = Time.time + attackspeed;
            Attack();

        }
        
    }

    void Attack(){
        animator.SetTrigger("Attack");
        Collider2D[] enemy_hit = Physics2D.OverlapCircleAll(attack_point.position,attack_range,enemyLayer);
        foreach(Collider2D enemy in enemy_hit){
            Enemy en = enemy.gameObject.GetComponent<Enemy>();
            en.RecieveDamage(Damage);
        }
    }
}
