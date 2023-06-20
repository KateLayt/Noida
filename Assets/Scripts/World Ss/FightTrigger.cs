using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightTrigger : MonoBehaviour
{
    public BossFightController con;

    void OnTriggerEnter2D(Collider2D collider)
    {
        con.AddTarget(collider.gameObject.transform.parent.gameObject);
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        con.RemoveTarget(collider.gameObject.transform.parent.gameObject);
    }
}

