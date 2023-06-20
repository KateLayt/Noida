using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointBeh : MonoBehaviour
{
    public GameObject character;
    public float timer = 5;
    SpriteRenderer sr;
    Color col;
    public float disspead = 1;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        character = GameObject.Find("Char");
        ChacterController con = character.GetComponent<ChacterController>();
        con.GetPoint(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        col = sr.color;
        col.a -= disspead * Time.deltaTime;
        sr.color = col;
        if (timer < 0)
        {
            Destroy(gameObject);
        }
    }
}
