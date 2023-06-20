using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkillButton : MonoBehaviour
{

    public Image mask;
    float originalSize, sizeValue = 1;
    float timer = 0.3f;
    public string skill = "none";
    public CharAttackController at_con;
    public ChacterController ch_con;
    public bool paused = false;
    Button button;
    GameObject target;
    public float cooldown = 1f;
    public GameObject potion_count;

    void Start()
    {
        originalSize = mask.rectTransform.rect.height;
        button = GetComponentInChildren<Button>();
    }

    void Update()
    {
        if (sizeValue > 0)
        {
            if (timer < 0)
            {
                sizeValue -= 0.1f;
                mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, originalSize * sizeValue);
                timer = cooldown/10;
            }
            timer -= Time.deltaTime;
        }
        else if (button.enabled == false)
        {
            button.enabled = true;
        }
    }

    public void Use()
    {
        target = GameObject.Find("Wolf(Clone)");
        if (sizeValue > 0)
        {
            return;
        }

        switch (skill)
        {
            case "heal":
                at_con.AimAttack(target);
                at_con.skill = "heal";
                break;
            case "buff":
                at_con.AimAttack(target);
                at_con.skill = "buff";
                break;
            case "potion":
                Text count = potion_count.GetComponent<Text>();
                int c = Int32.Parse(count.text);
                if (c > 0)
                {
                    at_con.Potion();
                    c -= 1;
                    count.text = c.ToString();
                }
                else
                {
                    return;
                }
                break;
            default:
                break;
        }
        button.enabled = false;
        sizeValue = 1.1f;
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 1f);
    }

}
