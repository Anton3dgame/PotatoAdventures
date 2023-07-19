using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{

    [SerializeField] public GameObject door;

    private bool isButtonActivated = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (!isButtonActivated)
        {
            isButtonActivated = true;
            Vector3 localscale = transform.localScale;
            localscale.x *= -1f;
            transform.localScale = localscale;
            if (door.activeSelf)
            {
                door.SetActive(false);
            }
            else
            {
                door.SetActive(true);
            }
        }
    } 

    /* if (collision.gameObject.CompareTag("Lever1"))
        {

        }
        else if (collision.gameObject.CompareTag("Lever2"))
        {

        }
        else if (collision.gameObject.CompareTag("Lever3"))
        {

        }
        else if (collision.gameObject.CompareTag("Lever4"))
        {

        }


        Vector3 localscale = transform.localScale;
    localscale.x *= -1f;
        transform.localScale = localscale;
        if (door.activeSelf)
        {
            door.SetActive(false);
        }
        else
{
    door.SetActive(true);
}*/
}
