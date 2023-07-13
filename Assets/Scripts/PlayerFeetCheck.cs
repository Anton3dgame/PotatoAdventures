using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFeetCheck : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.GetComponent<EnemyHeadCheck>())
        {
             this.gameObject.GetComponentInParent<EnemyLife>().TakeDamage(1);
        } 
    }
}
