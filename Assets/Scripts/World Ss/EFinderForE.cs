using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EFinderForE : MonoBehaviour
{
    public GameObject target = null;
    public EnemyController con;
    // Start is called before the first frame update
    void Start()
    {
        con = transform.parent.gameObject.GetComponent<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            GameObject en = target.transform.parent.gameObject;
            if (en.TryGetComponent<ChacterController>(out ChacterController character))
            {
                con.AttackHero(en);
            }
            if (en.TryGetComponent<WolfController>(out WolfController wolf))
            {
                con.AttackWolf(en);
            }
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
        else
        {
            GameObject new_en = collider.gameObject.transform.parent.gameObject;
            if (new_en.TryGetComponent<WolfController>(out WolfController wolf))
            {
                target = collider.gameObject;
            }
        }
        con.TakeDamage(0f);
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

