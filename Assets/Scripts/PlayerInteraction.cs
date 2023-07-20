using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    private bool isOnDirtObject = false;
    private bool isOnVineObject = false;
    private bool isOnGrassObject = false;

    private GameObject interactingObject1;
    private GameObject interactingObject2;
    private GameObject interactingObject3;
    public GameObject objectToCreate;    // was gespawnt wird

    public bool codePanelactive = false;

    public bool gravity = false;

    public bool _story = false;

    // Update is called once per frame
    void Update()
    {
        // Erdeblock zerstören
        if (isOnDirtObject && Input.GetKeyDown(KeyCode.Alpha1) && gameObject.GetComponent<ItemCollector>().shovel)
        {
            Destroy(interactingObject1);
        }

        // Ranken zerstören
        if (isOnVineObject && Input.GetKeyDown(KeyCode.Alpha2) && gameObject.GetComponent<ItemCollector>().torch)
        {
            Destroy(interactingObject2);
        }

        // Ranken wachsen lassen
        if (isOnGrassObject && Input.GetKeyDown(KeyCode.Alpha3) && gameObject.GetComponent<ItemCollector>().water)
        {
            CreateOject();
        }

    }


    // Block den man mit der Schaufel/Fackel zerstören kann bzw. mit Wasser erstellen kann
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ShovableBlock"))
        {
            isOnDirtObject = true;
            interactingObject1 = collision.gameObject;
        }

        if (collision.gameObject.CompareTag("BurnableBlock"))
        {
            isOnVineObject = true;
            interactingObject2 = collision.gameObject;
        }

        if (collision.gameObject.CompareTag("GrowableBlock"))
        {
            isOnGrassObject = true;
            interactingObject3 = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ShovableBlock"))
        {
            isOnDirtObject = false;
            interactingObject1 = null;
        }

        if (collision.gameObject.CompareTag("BurnableBlock"))
        {
            isOnVineObject = false;
            interactingObject2 = null;
        }

        if (collision.gameObject.CompareTag("GrowableBlock"))
        {
            isOnGrassObject = false;
            interactingObject3 = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Code"))
        {
            codePanelactive = true;
        }

        if (collision.gameObject.CompareTag("Story"))
        {
            _story = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Code"))
        {
            codePanelactive = false;
        }

        if (collision.gameObject.CompareTag("Gravity"))
        {
            if (!gravity)
            {
                gravity = true;
            }
            else
            {
                gravity = false;
            }
        }
    }

    private void CreateOject()
    {
        Vector3 spawnPosition = interactingObject3.transform.position + new Vector3(0f, 1f, 0f);
        Quaternion spawnRotation = Quaternion.identity;

        GameObject newObject = Instantiate(objectToCreate, spawnPosition, spawnRotation);
    }
}
