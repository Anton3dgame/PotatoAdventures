using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityShift : MonoBehaviour
{
    public Rigidbody2D playerRigidbody;
    public Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
   
        if (gameObject.GetComponent<PlayerInteraction>().gravity)
        {
            playerRigidbody.gravityScale = -2f;
            playerTransform.localScale = new Vector3(1f, -1f, 1f);
            StartCoroutine(DelayedLoadScene());

        }
        else
        {
            playerRigidbody.gravityScale = 2f;
            playerTransform.localScale = new Vector3(1f, 1f, 1f);
            StartCoroutine(DelayedLoadScene());

        }
    }

    private IEnumerator DelayedLoadScene()
    {
        yield return new WaitForSeconds(0.2f);
    }
}
