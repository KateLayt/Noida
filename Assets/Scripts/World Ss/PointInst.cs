using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointInst : MonoBehaviour
{
    public GameObject Point;
    Ray2D ray;
    RaycastHit2D hit;
    public float timer = 0;
    bool enable = false;
    
   
    // Start is called before the first frame update
    void Start()
    {
    }



// Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        if (enable)
        {
            timer -= Time.deltaTime;
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit)
            {

                if (Input.GetKey(KeyCode.Mouse0) & timer < 0)
                {
                    GameObject obj = Instantiate(Point, new Vector2(hit.point.x, hit.point.y), Quaternion.identity) as GameObject;
                    timer = 0.7f;
                }

            }
        }
    }

    public void Pause()
    {
        timer = 10000000f;
    }

    public void Enable()
    {
        enable = true;
    }

    public void Disable()
    {
        enable = false;
    }

    public void Resume()
    {
        timer = -1f;
    }
}
