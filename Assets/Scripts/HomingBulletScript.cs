using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBulletScript : MonoBehaviour
{
    public float speed = 5f;
    Transform player; 
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Destroy(this.gameObject, 5);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed*Time.deltaTime);
    }
}
