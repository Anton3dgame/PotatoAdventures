using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Image schuhe;
    public Image fackel;
    public Image wasser;
    public Image schaufel;

    // Start is called before the first frame update
    void Start()
    {
        schuhe.enabled = false;
        schaufel.enabled = false;
        wasser.enabled = false;
        fackel.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<ItemCollector>().shoe)
        {
            schuhe.enabled = true;
        }

        if (gameObject.GetComponent<ItemCollector>().water)
        {
            wasser.enabled = true;
        }

        if (gameObject.GetComponent<ItemCollector>().shovel)
        {
            schaufel.enabled = true;
        }

        if (gameObject.GetComponent<ItemCollector>().torch)
        {
            fackel.enabled = true;
        }
    }
}

