using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class CheatCode : MonoBehaviour
{
    public GameObject player;
    public GameObject water;
    public GameObject torch;
    public GameObject shovel;
    public GameObject shoes;
    // Start is called before the first frame update
    private bool einmal = true;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && einmal)
        {
            water.transform.position = new Vector2(58.5f, 12f);
            torch.transform.position = new Vector2(58.5f, 12f);
            shovel.transform.position = new Vector2(58.5f, 12f);
            shoes.transform.position = new Vector2(58.5f, 12f);
            player.transform.position = new Vector2(58.5f, 12f);
            einmal = false;
        }

    }
}
