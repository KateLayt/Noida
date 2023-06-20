using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class GameBarCon : MonoBehaviour
{
    public GameObject point0, point1, gameset, point, cup, item, error, hotspot1, hotspot2;
    bool playing = false, moving = false, colling = false, clicking = false;
    RectTransform rt, point_rt;
    public float p_speed = 100f;
    int p = 0, hits = 0, dir = -1;
    HandleCon hc;
    public Text counter1, counter2;
    public CountHolder ch;
    Image hsr1, hsr2;
    public Sprite hsactive, hspassive;
    string collname;
    float spottimer = 0f;
    bool spot = false;

    // Start is called before the first frame update
    void Start()
    {
        rt = GetComponent<RectTransform>();
        hc = cup.GetComponent<HandleCon>();
        hsr1 = hotspot1.GetComponent<Image>();
        hsr2 = hotspot2.GetComponent<Image>();
        p_speed = Screen.width * 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (spot)
        {
            spottimer -= Time.deltaTime;
            if (spottimer < 0)
            {
                if (collname == "Hotspot 1")
                {
                    hsr1.sprite = hspassive;
                }
                if (collname == "Hotspot 2")
                {
                    hsr2.sprite = hspassive;
                }
                spot = false;
            }
        }

        if (playing)
        {
            
            switch (p)
            {
                case 0: point = point0; break;
                case 1: point = point1; break;

            }
            point_rt = point.GetComponent<RectTransform>();
            MoveTowards(point_rt.position, 1);
            if (!moving)
            {
                p = (p + 1) % 2;
                dir = -dir;
            }


            if (colling && Input.GetMouseButtonDown(0) && !clicking)
            {
                clicking = true;
                hits += 1;
                hc.Move();
                if (collname == "Hotspot 1")
                {
                    hsr1.sprite = hsactive;
                }
                if (collname == "Hotspot 2")
                {
                    hsr2.sprite = hsactive;
                }
                spot = true;
                spottimer = 0.3f;
                if (hits == 3){
                    SetGame(false);
                    ch.Change("Koluka", -1);
                    ch.Change("Apple", -1);
                    hc.Stop();
                    item.SetActive(true);
                }
            }
            if (clicking && Input.GetMouseButtonUp(0))
            {
                /*if (collname == "Hotspot 1")
                {
                    hsr1.sprite = hspassive;
                }
                if (collname == "Hotspot 2")
                {
                    hsr2.sprite = hspassive;
                }*/
                clicking = false;
            }
        }
    }

    public void Refresh()
    {
        error.SetActive(false);
        SetGame(false);
    }


    void MoveTowards(Vector3 pos, float distance)
    {
        Vector3 position = rt.position;
        if ((Math.Abs(pos.x - position.x) > 15))
        {
            moving = true;
            position.x = position.x + dir * p_speed * Time.deltaTime;
            rt.position = position;
        }
        else
        {
            moving = false;
        }
    }

    public void SetGame(bool val)
    {
        gameset.SetActive(val);
        if (val == true)
        {
            if (Int32.Parse(counter1.text) > 0 && Int32.Parse(counter2.text) > 0)
            {
                playing = true;
                hits = 0;
            }
            else
            {
                error.SetActive(true);
            }
        }
        else
        {
            playing = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        colling = true;
        collname = collider.gameObject.name;
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        colling = false;
    }
}
