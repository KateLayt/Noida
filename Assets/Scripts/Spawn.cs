using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public ChacterController ch;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collider)
    {
        ch.on_spawn = true;
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        ch.on_spawn = false;
    }
}
