using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEffect : MonoBehaviour
{
    // Start is called before the first frame update

    float time_ticker = 300f;
    public bool right = true;
    public float speed = 3f;

    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        time_ticker -= Time.deltaTime;
        if (time_ticker < 0)
        {
            right = !right;
            time_ticker = 300f;
        }

        if (right)
        {
            transform.position += new Vector3(1, 0, 0)*Time.deltaTime*(speed*0.3f);
        }
        else
        {
            transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * (speed*0.3f);
        }
    }
}
