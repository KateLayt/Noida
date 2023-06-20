using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBeh : MonoBehaviour
{
    private GameObject character;
    private CharAttackController con;
    private Vector2 direction;
    private Rigidbody2D rb;
    private Vector2 pos;
    private float lifetime = 3;
    private float speed = 5;
    private string skill = "none";
    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.Find("Char");
        con = character.GetComponent<CharAttackController>();
        rb = GetComponent<Rigidbody2D>();
        switch (con.dir)
        {
            case "down":
                direction = new Vector2(0, -1); break;
            case "up":
                direction = new Vector2(0, 1); break;
            case "right":
                direction = new Vector2(1, 0); break;
            case "left":
                direction = new Vector2(-1, 0); break;
            default:
                direction = new Vector2(0, 0); break;
        }

        skill = con.skill;

    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime < 0)
        {
            Dissapear();
        }
    }

    void FixedUpdate()
    {
        pos = transform.position;
        pos.x += direction.x * Time.deltaTime * speed;
        pos.y += direction.y * Time.deltaTime * speed;
        rb.MovePosition(pos);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject target = collider.gameObject;
        WolfController wolf = target.GetComponent<WolfController>();
        if (wolf != null)
        {
            switch (skill)
            {
                case "heal":
                    wolf.Heal(20f);
                    break;
                case "buff":
                    wolf.GetBuff();
                    break;
                default:
                    break;
            }
        }
        Dissapear();
    }

    void Dissapear()
    {
        Destroy(gameObject);
    }

    //Можно сделать два коллайдера на волке, для горизонтали и для вертикали, чтобы хилы не так ущербно смотрелись.
    //Можно больше, но нужен определитель направления по координатам тогда.
}
