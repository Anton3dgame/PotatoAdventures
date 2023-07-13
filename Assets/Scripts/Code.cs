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
    public bool rightCode = false;
    public GameObject door;

    void Start()
    {
        codePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if ((gameObject.GetComponent<PlayerInteraction>().codePanelactive))
        {
            codePanel.SetActive(true);
        }
        else
        {
            codePanel.SetActive(false);
        }

        codeText.text = codeTextValue;

        if (codeTextValue == "1234")
        {
            rightCode = true;
        }

        if (codeTextValue.Length == 4 && !rightCode)
        {
            StartCoroutine(DelayedLoadScene());
        }

        if (rightCode)
        {
            Destroy(door);
        }
    }

    public void AddDigit(string digit)
    {
        codeTextValue += digit;
    }

    private IEnumerator DelayedLoadScene()
    {
        yield return new WaitForSeconds(0.2f);
        codeTextValue = "";
    }

}
