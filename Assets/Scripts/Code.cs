using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Code : MonoBehaviour
{
    public GameObject codePanel;
    [SerializeField] Text codeText;
    public string codeTextValue = "";
    private bool rightCode = false;
    private bool finishedCode = false;
    public GameObject door;
    public Image image;
    int length = 4;

    void Start()
    {
        codePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
         if (!finishedCode)
         {
             if ((gameObject.GetComponent<PlayerInteraction>().codePanelactive))
             {
                 codePanel.SetActive(true);
             }
             else
             {
                 codePanel.SetActive(false);
             }
         } 

        codeText.text = codeTextValue;

        if (codeTextValue == "1234")
        {
            rightCode = true;
            image.color = new Color(0.13f, 0.85f, 0f, 0.39f);
            StartCoroutine(DelayedLoadScene2());
        }

        if (codeTextValue.Length == 4 && !rightCode)
        {
            image.color = new Color(0.67f, 0f, 0f, 0.39f);
            StartCoroutine(DelayedLoadScene());
        } 

        if (rightCode)
        {
            Destroy(door);
        } 
    }

    public void AddDigit(string digit)
    {
        if (codeTextValue.Length < length)
        {
            codeTextValue += digit;
        }
    }

    private IEnumerator DelayedLoadScene()
    {
        yield return new WaitForSeconds(0.2f);
        image.color = new Color(1f, 1f, 1f, 0.39f);
        codeTextValue = "";
    }
    private IEnumerator DelayedLoadScene2()
    {
        yield return new WaitForSeconds(1f);
        codePanel.SetActive(false);
        finishedCode = true;
    } 



}