using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
public class EnemyHeadCheck : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerFeetCheck>())
        {
            rb.velocity = new Vector2(rb.velocity.x, 9f);
        }
    }
}
