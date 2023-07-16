using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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

    public Image heart_1;
    public Image heart_2;
    public Image heart_3;
    public Image heart_4;
    public Image heart_5;

    public GameObject Leben;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        Leben.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth == 4)
        {
            heart_5.enabled = false;
        }

        if (currentHealth == 3)
        {
            heart_4.enabled = false;
        }

        if (currentHealth == 2)
        {
            heart_3.enabled = false;
        }

        if (currentHealth == 1)
        {
            heart_2.enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Life"))
        {
            Leben.SetActive(true);
        }
    }

    public void TakeDamage(int amount)
    {       
        currentHealth -= amount;
        if (currentHealth<=0)
        {
            heart_1.enabled = false;
            Destroy(gameObject);
        }
    }
 
}
