using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFinder : MonoBehaviour
{
    public GameObject target = null;
    public WolfController con;
    // Start is called before the first frame update
    void Start()
    {
        con = transform.parent.gameObject.GetComponent<WolfController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            GameObject en = target.transform.parent.gameObject;
            con.Attack(en);
        }
        else
        {
            con.StopAttack();
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (target == null)
        {
            target = collider.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject == target)
        {
            target = null;
            con.StopAttack();
        }
    }

}
