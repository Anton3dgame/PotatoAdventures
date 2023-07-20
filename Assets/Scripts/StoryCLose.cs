using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StoryCLose : MonoBehaviour
{
    public GameObject story;
    // Start is called before the first frame update
    void Start()
    {
        story.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<PlayerInteraction>()._story)
        {
            story.SetActive(true);
        }
        else
        {
            story.SetActive(false);
        }
    }

    public void Close()
    {
        gameObject.GetComponent<PlayerInteraction>()._story = false;
        story.SetActive(false);
    }
}