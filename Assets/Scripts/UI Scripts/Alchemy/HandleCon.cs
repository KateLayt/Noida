using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HandleCon : MonoBehaviour
{
    public int point_count = 8, cur_point = 8;
    bool moving = true;
    RectTransform own_rt, point_rt;
    Vector3 own_pos, point_pos;
    public GameObject points;
    public float speed = 3f;
    Vector3 diff;
    float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        own_rt = GetComponent<RectTransform>();
        speed = Screen.width * 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            GameObject point = points.transform.GetChild(cur_point).gameObject;
            point_rt = point.GetComponent<RectTransform>();

            own_pos = own_rt.position;
            point_pos = point_rt.position;

            if (Math.Abs(point_pos.x - own_pos.x) > 10 || Math.Abs(point_pos.y - own_pos.y) > 10)
            {
                diff = new Vector3(point_pos.x - own_pos.x, point_pos.y - own_pos.y, 0);
                diff.Normalize();
                own_rt.position += diff * speed * Time.deltaTime;
            }
            else
            {
                cur_point = (cur_point + 1) % point_count;
            }

            timer -= Time.deltaTime;
            if (timer < 0)
            {
                moving = false;
            }
        }
    }

    public void Move()
    {
        moving = true;
        timer = 2f;
    }

    public void Stop()
    {
        moving = false;
    }
}
