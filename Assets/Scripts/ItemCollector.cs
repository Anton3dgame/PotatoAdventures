using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemCollector : MonoBehaviour
{
    public bool shoe;
    public bool shovel;
    public bool torch;
    public bool water;

    // Start is called before the first frame update
    void Start()
    {
        shoe = false;
        shovel = false;
        torch = false;
        water = false;
    }

    // guckt ob man das jeweilige Objekt eingesammelt hat und setzt dann den jeweiligen Boolean auf true
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Shoe"))
        {
            Destroy(collision.gameObject);
            shoe = true;
        }

        if (collision.gameObject.CompareTag("Shovel"))
        {
            Destroy(collision.gameObject);
            shovel = true;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);  // nur zum Test hier
        }

        if (collision.gameObject.CompareTag("Torch"))
        {
            Destroy(collision.gameObject);
            torch = true;
        }

        if (collision.gameObject.CompareTag("Water"))
        {
            Destroy(collision.gameObject);
            water = true;
        }

    }
}
