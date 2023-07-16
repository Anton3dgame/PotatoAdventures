using UnityEngine;

public class IncreaseCameraSize : MonoBehaviour
{
    [SerializeField] private Camera myCamera;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            myCamera.orthographicSize = 5;
        }
    }
}
