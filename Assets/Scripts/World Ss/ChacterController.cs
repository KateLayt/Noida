using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class ChacterController : MonoBehaviour
{
    public Vector2 pointpos; 
    private Vector2 charpos, prevpos;
    float stucktimer = 0.1f;
    public Vector2 diff;
    private Rigidbody2D rigidbody2d;
    public float speed = 3.5f;
    Animator animator;
    public float maxHealth = 30;
    private float currentHealth;
    private CharAttackController a_controller;
    public bool on_spawn = false;


    // Start is called before the first frame update
    void Start()
    {
        charpos = transform.position;
        pointpos = charpos;
        prevpos = charpos;
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        LevXP.instance.SetValue(0f);

    }

    // Update is called once per frame
    void Update()
    {
        charpos = transform.position;
        diff.Set(pointpos.x - charpos.x, pointpos.y - charpos.y);
        diff.Normalize();
        animator.SetFloat("MoveX", diff.x);
        animator.SetFloat("MoveY", diff.y);

    }

    void FixedUpdate()
    {
        charpos = transform.position;
        if ((Math.Abs(pointpos.x - charpos.x) > 0.2) || (Math.Abs(pointpos.y - charpos.y) > 0.2))
        {
            if ((Math.Abs(prevpos.x - charpos.x) < 0.01) && (Math.Abs(prevpos.y - charpos.y) < 0.01))
            {
                stucktimer -= Time.deltaTime;
                if (stucktimer < 0)
                {
                    Stop();
                    stucktimer = 0.1f;
                    return;
                }
            }
            animator.SetBool("Moving", true);
            Vector2 position = rigidbody2d.position;
            position.x = position.x + speed * diff.x * Time.deltaTime;
            position.y = position.y + speed * diff.y * Time.deltaTime;

            rigidbody2d.MovePosition(position);
        }
        else
        {
            stucktimer = 0.1f;
            animator.SetBool("Moving", false);
        }
        prevpos = charpos;

    }

    public void ChangeHealth(float value)
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
        DudeHP.instance.SetValue(currentHealth / maxHealth);
        if (currentHealth == 0)
        {
            Die();
        }
    }

    public void TakeDamage(float val)
    {
        ChangeHealth(-val);
    }

    public void GetPoint(Vector2 pos)
    {
        pointpos = pos;
    }

    public void Stop()
    {
        GetPoint(charpos + diff * 0.1f);
        animator.SetFloat("MoveX", diff.x);
        animator.SetFloat("MoveY", diff.y);
    }

    public void Die()
    {
        transform.position = new Vector3(-51, -36, 0);
        ChangeHealth(maxHealth);
        pointpos = transform.position;
    }
}
