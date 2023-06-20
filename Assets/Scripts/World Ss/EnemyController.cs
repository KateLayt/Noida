using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyController : MonoBehaviour
{
    private Vector2 wolfpos, diff;
    private Rigidbody2D rigidbody2d;
    public float a_speed = 1.5f, w_speed = 1f;
    float cur_speed;
    Animator animator;
    GameObject Character;
    bool attacking_state = false;
    bool moving = false;
    public GameObject point, point0, point1, point2, point3;
    int p = 0;
    public float strenght = 1f;
    public float maxHealth = 7f;
    private float currentHealth;
    public float attack_speed = 1.5f;
    float a_time = 1.5f;
    public float exp_reward = 0.04f;


    // Start is called before the first frame update
    void Start()
    {
        wolfpos = transform.position;
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Vector2 position = rigidbody2d.position;
        point = point0;
        currentHealth = maxHealth;
        cur_speed = w_speed;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        Transform point_tr;
        if (!attacking_state && point)
        {
            switch (p)
            {
                case 0: point = point0; break;
                case 1: point = point1; break;
                case 2: point = point2; break;
                case 3: point = point3; break;

            }
            point_tr = point.GetComponent<Transform>();
            MoveTowards(point_tr.position, 1);
            if (!moving)
            {
                p = (p + 1) % 4;
            }
        }
    }


    void MoveTowards(Vector2 pos, float distance)
    {
        wolfpos = transform.position;
        if ((Math.Abs(pos.x - wolfpos.x) > distance) || (Math.Abs(pos.y - wolfpos.y) > distance))
        {
            moving = true;
            Vector2 position = rigidbody2d.position;
            position.x = position.x + cur_speed * diff.x * Time.deltaTime;
            position.y = position.y + cur_speed * diff.y * Time.deltaTime;

            rigidbody2d.MovePosition(position);
        }
        else
        {
            moving = false;
        }
        animator.SetBool("Moving", moving);
        diff.Set(pos.x - wolfpos.x, pos.y - wolfpos.y);
        diff.Normalize();
        animator.SetFloat("MoveX", diff.x);
        animator.SetFloat("MoveY", diff.y);
    }

    public void AttackHero(GameObject en_obj)
    {
        cur_speed = a_speed;
        ChacterController enemy = en_obj.GetComponent<ChacterController>();
        Rigidbody2D enemy_rb = en_obj.GetComponent<Rigidbody2D>();
        Vector2 e_pos = enemy_rb.position;
        float distance = 1f;
        attacking_state = true;

        a_time -= Time.deltaTime;
        MoveTowards(e_pos, 1f);
        if ((Math.Abs(e_pos.x - wolfpos.x) < distance) && (Math.Abs(e_pos.y - wolfpos.y) < distance))
        {
            animator.SetBool("Attacking", true);
            if (a_time < 0)
            {
                enemy.TakeDamage(strenght);
                a_time = attack_speed;
            }
        }

        else
        {
            animator.SetBool("Attacking", false);
        }
    }

    public void AttackWolf(GameObject en_obj)
    {
        cur_speed = a_speed;
        WolfController enemy = en_obj.GetComponent<WolfController>();
        Rigidbody2D enemy_rb = en_obj.GetComponent<Rigidbody2D>();
        Vector2 e_pos = enemy_rb.position;
        float distance = 2f;
        attacking_state = true;

        a_time -= Time.deltaTime;
        MoveTowards(e_pos, 1f);
        if ((Math.Abs(e_pos.x - wolfpos.x) < distance) && (Math.Abs(e_pos.y - wolfpos.y) < distance))
        {
            animator.SetBool("Attacking", true);
            if (a_time < 0)
            {
                enemy.TakeDamage(strenght);
                a_time = attack_speed;
            }
        }

        else
        {
            animator.SetBool("Attacking", false);
        }
    }

    public void StopAttack()
    {
        cur_speed = w_speed;
        attacking_state = false;
        animator.SetBool("Attacking", false);
    }

    public void TakeDamage(float damage)
    {
        ChangeHealth(-damage);
        if (currentHealth == 0)
        {
            Die();
        }
    }

    void ChangeHealth(float value)
    {
        if ((currentHealth + value <= maxHealth) & (currentHealth + value >= 0))
        {
            currentHealth += value;
        }
        else
        {
            if (currentHealth + value > maxHealth)
            {
                currentHealth = maxHealth;
            }
            else
            {
                currentHealth = 0;
            }
        }
        EnemyHP.instance.SetValue(currentHealth / maxHealth);
    }

    void Die()
    {
        Destroy(gameObject);
        LevXP.instance.SetValue(LevXP.instance.val + exp_reward);
    }

}
