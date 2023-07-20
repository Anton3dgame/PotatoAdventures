using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableTipps : MonoBehaviour
{
    public GameObject tippscreen;
    private bool open = false;

    void Start()
    {
        tippscreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (open)
        {
            tippscreen.SetActive(true);
        }
        else
        {
            tippscreen.SetActive(false);
        }
    }

    public void Click()
    {
        open = !open;
    }
}
