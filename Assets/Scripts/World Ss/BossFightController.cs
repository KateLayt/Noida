using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightController : MonoBehaviour
{
    bool fighting;
    public GameObject char_target = null, wolf_target = null;
    public EnemyController con;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fighting)
        {
            if (wolf_target != null)
            {
                con.AttackWolf(wolf_target);
                return;
            }
            else if (char_target != null) 
            {
                con.AttackHero(char_target);
            }
            else
            {
                fighting = false;
                con.StopAttack();
            }
        }
    }


    public void AddTarget(GameObject target)
    {
        fighting = true;
        if (target.TryGetComponent<ChacterController>(out ChacterController character))
        {
            char_target = target;
        }
        if (target.TryGetComponent<WolfController>(out WolfController wolf))
        {
            wolf_target = target;
        }
    }

    public void RemoveTarget(GameObject target)
    {
        if (target.TryGetComponent<ChacterController>(out ChacterController character))
        {
            char_target = null;
        }
        if (target.TryGetComponent<WolfController>(out WolfController wolf))
        {
            wolf_target = null;
        }
    }

}
