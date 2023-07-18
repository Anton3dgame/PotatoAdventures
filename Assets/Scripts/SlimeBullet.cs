using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SlimeBullet : MonoBehaviour
{
    GameObject target;
    public float speed;
    Rigidbody2D bulletRB;
    public int reli;
    public int obun;
    public int time;
    // Start is called before the first frame update
    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = new Vector2(reli, obun).normalized * speed;
        bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
        Destroy(this.gameObject, time);
    }
}

