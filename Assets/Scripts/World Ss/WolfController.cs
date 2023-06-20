using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WolfController : MonoBehaviour
{
    private Vector2 charpos, wolfpos, diff;
    private Rigidbody2D rigidbody2d;
    public float a_speed = 3, w_speed = 2;
    float cur_speed = 2;
    Animator animator;
    public float attack_speed = 1f;
    public float a_time = 1f;
    GameObject Character;
    bool attacking_state = false;
    bool moving = false;
    public float strenght = 1f;
    public float maxHealth = 20f;
    private float currentHealth;
    private SpriteRenderer sr;
    private float basic_str = 1f, buffed_str = 3f;
    public float buff_val = 2f;
    bool buffed = false;
    float buff_timer = 5f;
    public GameObject effect, particles;



    // Start is called before the first frame update
    void Awake()
    {
        wolfpos = transform.position;
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Vector2 position = rigidbody2d.position;
        ChangeHealth(maxHealth);
        sr = GetComponent<SpriteRenderer>();
        basic_str = strenght;
        buffed_str = strenght * buff_val;
    }

    // Update is called once per frame
    void Update()
    {
        GetCharPosition();
        if (buffed)
        {
            buff_timer -= Time.deltaTime;
            if (buff_timer < 0)
            {
                buffed = false;
                strenght = basic_str;
            }
        }
    }


    void FixedUpdate()
    {
        if (!attacking_state){
            MoveTowards(charpos, 1.5f);
        }
    }

    public void GetCharPosition()
    {
        Character = GameObject.Find("Char");
        Rigidbody2D rb = Character.GetComponent<Rigidbody2D>();
        charpos = rb.position;
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

    public void Attack(GameObject en_obj)
    {
        EnemyController enemy = en_obj.GetComponent<EnemyController>();
        Rigidbody2D enemy_rb = en_obj.GetComponent<Rigidbody2D>();
        Vector2 e_pos = enemy_rb.position;
        float distance = 2f;
        attacking_state = true;

        cur_speed = a_speed;

        a_time -= Time.deltaTime;
        MoveTowards(e_pos, 0.6f);
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
        WolfHP.instance.SetValue(currentHealth / maxHealth);
    }

    public void StopAttack()
    {
        cur_speed = w_speed;
        attacking_state = false;
        animator.SetBool("Attacking", false);
    }

    void Die()
    {
        Destroy(gameObject);
    }

    public void Heal(float value)
    {
        ChangeHealth(value);
        particles.SetActive(true);
    }

    public void GetBuff()
    {
        strenght = buffed_str;
        buffed = true;
        buff_timer = 5f;

        effect.SetActive(true);
        Effect ef_con = effect.GetComponent<Effect>();
        ef_con.PlayEffect();
    }
}
