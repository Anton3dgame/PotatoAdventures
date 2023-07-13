using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
public class EnemyLife : MonoBehaviour
{
    private Rigidbody2D rb;
    public int maxHealth = 5;
    public int currentHealth;
    private bool damage = false;


    private float damageTimer = 0.5f; // Zeitintervall für den Schaden
    private float currentTimer = 0.6f; // Aktueller Timer für den Schaden
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
   

    }

    public void TakeDamage(int amount)
    {       
        currentHealth -= amount;
        if (currentHealth<=0)
        {
            Destroy(gameObject);
        }
    }
 
}
