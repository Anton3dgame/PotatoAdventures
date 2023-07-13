using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private int lifes = 3;
    private bool damage = false;
    private bool hitByBullet = false;

    private float damageTimer = 0.5f; // Zeitintervall für den Schaden
    private float currentTimer = 0.6f; // Aktueller Timer für den Schaden

    public Image heart_1;
    public Image heart_2;
    public Image heart_3;

    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (lifes == 2)
        {
            heart_3.enabled = false;
        }

        if (lifes == 1)
        {
            heart_2.enabled = false;
        }

        if (lifes == 0)
        {
            heart_1.enabled = false;
        }

        if (damage)
        {
            if (currentTimer >= damageTimer)
            {
                currentTimer = 0f;
                if (lifes == 1)
                {
                    Die();
                }
                if (lifes > 0)
                {
                    lifes--;
                }
            }

            currentTimer += Time.deltaTime;
        }

        if (!damage)
        {
            currentTimer = 0.6f;
        }
        if(hitByBullet)
        {
            hitByBullet = !hitByBullet;
            damage = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            damage = true;
           
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            damage = false;
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Heal") && lifes < 3)
        {
            Destroy(collision.gameObject);
            Heal();

        }
        else if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            hitByBullet = true;
            damage = true;
        }
    }

    private void Heal()
    {
        lifes++;
        if (lifes == 3)
        {
            heart_3.enabled = true;
        }
        else
        {
            heart_2.enabled = true;
        }
    }

    private IEnumerator DelayedLoadScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");

        StartCoroutine(DelayedLoadScene());
    }

  /*  private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    } */
}
