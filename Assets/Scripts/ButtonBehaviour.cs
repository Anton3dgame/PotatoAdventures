using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{

    [SerializeField] public GameObject door;

    private void OnTriggerEnter2D(Collider2D collision)
    {
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
