using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class MovingItem : MonoBehaviour
{
    public GameObject goal;
    RectTransform goal_rt, own_rt;
    float goal_width, goal_height, cur_val;
    public GameObject counter;
    public float movespeed = 50f, growthspeed = 0.03f;
    Vector3 initial_pos;
    float initial_size;
    // Start is called before the first frame update
    void Awake()
    {
        goal_rt = goal.GetComponent<RectTransform>(); 
        own_rt = GetComponent<RectTransform>();
        goal_width = goal_rt.rect.width/2f;
        goal_height = goal_rt.rect.height/2f;
        cur_val = own_rt.rect.width / goal_width;
        initial_size = cur_val;
        initial_pos = own_rt.position;
        movespeed = Screen.width * 0.4f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 diff = new Vector3(goal_rt.position.x - own_rt.position.x, (goal_rt.position.y - own_rt.position.y)/2, 0);
        if (Math.Abs(diff.x) > 3 || Math.Abs(diff.y) > 3)
        {
            diff.Normalize();
            own_rt.position += diff*movespeed*Time.deltaTime;
        }
        if (cur_val < 1)
        {
            cur_val += growthspeed * Time.deltaTime;
            Resize(cur_val);
        }

        else
        {
            Text count = counter.GetComponent<Text>();
            int c = Int32.Parse(count.text) + 1;
            count.text = c.ToString();
            own_rt.position = initial_pos;
            Resize(initial_size);
            Awake();
            gameObject.SetActive(false);
        }
    }

    void Resize(float value)
    {
        own_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, goal_width * value);
        own_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, goal_height * value);

    }
}
