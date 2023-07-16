using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreaseCameraSize : MonoBehaviour
{
    [SerializeField] private Camera myCamera;
    [SerializeField] private float camSize;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            myCamera.orthographicSize = camSize;
        }
    }
}
