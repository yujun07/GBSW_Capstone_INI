using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(speaking());   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator speaking()
    {
       
        yield return new WaitForSeconds(0.7f);
        Destroy(gameObject);
    }
}
