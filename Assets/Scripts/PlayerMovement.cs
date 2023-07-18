using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private BoxCollider2D coll;
    private int counter;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private LayerMask specialGround;

    public bool isGrounded = false;
    public LayerMask groundLayer;

    // Start is called before the first frame update
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        rigidbody.velocity = new Vector2(dirX * 7f, rigidbody.velocity.y);

        if (Input.GetButtonDown("Jump") && (IsGrounded() || IsSpecial()) && !gameObject.GetComponent<ItemCollector>().shoe)
        {

            if (gameObject.GetComponent<PlayerInteraction>().gravity)
            {
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, -8.7f);

            }
            else
            {
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, 8.7f);
            }

        }

        if (Input.GetButtonDown("Jump") && gameObject.GetComponent<ItemCollector>().shoe)
        {
            if (counter < 2)
            {
                if (gameObject.GetComponent<PlayerInteraction>().gravity)
                {
                    rigidbody.velocity = new Vector2(rigidbody.velocity.x, -10f);
                    counter++;
                }
                else
                {
                    rigidbody.velocity = new Vector2(rigidbody.velocity.x, 10f);
                    counter++;
                }
            }
        } else if (IsGrounded() || IsSpecial())
        {
            counter = 0;
        }

    }

    // guckt ob man Boden mit Layer Ground berührt
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.up, 0.1f, jumpableGround) || Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }

    private bool IsSpecial()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, specialGround) || Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.up, 0.1f, specialGround);
    }
}
