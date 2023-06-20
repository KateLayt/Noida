using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ticking : MonoBehaviour
{
    float ticker;
    public float val = 2f;
    ParticleSystem ps;
    // Start is called before the first frame update
    void Awake()
    {
        ticker = val;
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ticker > 0)
        {
            ticker -= Time.deltaTime;
        }
        else
        {
            ticker = val;
            gameObject.SetActive(false);
        }
    }
}
