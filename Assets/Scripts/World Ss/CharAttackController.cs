using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharAttackController : MonoBehaviour
{
    public float heal_value = 1f;
    private Animator animator;
    public float cur_x, cur_y;
    public GameObject arrowH, arrowV;
    private Vector3 pos;
    private float timer = 0.7f;
    private bool is_set = true;
    public string dir = "none", skill = "none";
    private ChacterController character;
    public DudeHP hp_controller;
    bool aiming = false;
    Vector3 target_pos;
    GameObject curr_target;
    Vector2 diff;
    Vector3 cpos1, cpos2;
    float stucktime = 1f;



    private float hp, maxhp = 60f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        character = GetComponent<ChacterController>();
        hp = maxhp;
        cpos1 = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (aiming)
        {
            cpos2 = transform.position;
            if (cpos1 == cpos2)
            {
                stucktime -= Time.deltaTime;
                if (stucktime < 0)
                {
                    aiming = false;
                    stucktime = 1f;
                    return;
                }
            }
            cpos1 = cpos2;

            AimAttack(curr_target);
            return;
        }
        if (!is_set)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                switch (skill)
                {
                    case "heal":
                        character.TakeDamage(5f);
                        break;
                    case "buff":
                        character.TakeDamage(10f);
                        break;
                    default:
                        break;

                }
                InstArrow();
                is_set = true;
            }
        }
    }

    public void Attack()
    {
        animator.Play("AttackBT");
        timer = 0.7f;
        is_set = false;
    }
    void InstArrow()
    {
        cur_x = animator.GetFloat("MoveX");
        cur_y = animator.GetFloat("MoveY");
        if (Math.Abs(cur_x) >= Math.Abs(cur_y))
        {
            if (cur_x > 0)
            {
                pos = new Vector3(transform.position.x + 1f, transform.position.y + 1f, transform.position.z);
                Instantiate(arrowH, pos, new Quaternion(0, 0, 180, 0));
                dir = "right";
            }
            else
            {
                pos = new Vector3(transform.position.x - 1f, transform.position.y + 1f, transform.position.z);
                Instantiate(arrowH, pos, new Quaternion(0, 0, 0, 0));
                dir = "left";
            }
        }
        else
        {
            if (cur_y > 0)
            {
                pos = new Vector3(transform.position.x, transform.position.y + 2.5f, transform.position.z);
                Instantiate(arrowV, pos, new Quaternion(0, 0, 180, 0));
                dir = "up";
            }
            else
            {
                pos = new Vector3(transform.position.x, transform.position.y - 1.5f, transform.position.z);
                Instantiate(arrowV, pos, new Quaternion(0, 0, 0, 0));
                dir = "down";
            }
        }
    }


    public void AimAttack(GameObject target)
    {
        Vector3 tarpos = target.transform.position;
        Vector3 pos = transform.position;
        curr_target = target;
        if (Math.Abs(pos.x - tarpos.x) < 0.2f || Math.Abs(pos.y - tarpos.y) < 0.2f)
        {
            diff.Set(tarpos.x - pos.x, tarpos.y - pos.y);
            diff.Normalize();
            character.diff = diff;
            character.Stop();
            Attack();
            aiming = false;
            return;
        }
        aiming = true;
        if (Math.Abs(pos.x - tarpos.x) <= Math.Abs(pos.y - tarpos.y))
        {
            character.GetPoint(new Vector2(tarpos.x, pos.y));
        }
        else
        {
            character.GetPoint(new Vector2(pos.x, tarpos.y));
        }
    }

    public void Potion()
    {
        character.ChangeHealth(15f);
    }
}
