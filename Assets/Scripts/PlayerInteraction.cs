using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
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

    private void CreateOject()
    {
        Vector3 spawnPosition = interactingObject3.transform.position + new Vector3(0f, 2f, 0f);
        Quaternion spawnRotation = Quaternion.identity;

        GameObject newObject = Instantiate(objectToCreate, spawnPosition, spawnRotation);
    }
}
