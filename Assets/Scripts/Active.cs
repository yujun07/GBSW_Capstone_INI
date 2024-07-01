using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active : MonoBehaviour
{
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickOn()
    {
        panel.SetActive(true);
    }

    public void ClickOff()
    {
        panel.SetActive(false);
    }
}
