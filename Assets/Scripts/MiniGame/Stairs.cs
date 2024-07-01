using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : GameController
{
    AyunAnimator ayunAnimator;
    public GameObject speakStair;
    public Transform position;
    
    private void Awake()
    {
        
        GameObject ayun = GameObject.Find("aYun");
        ayunAnimator = ayun.GetComponent<AyunAnimator>();
        
    }

    void OnEnable()
    {
        StartCoroutine(CheckMouseVec());
    }
    IEnumerator CheckMouseVec()
    {
        
        while (true)
        {
            float parentMouseVec = GetMouseVec();
            
            if (parentMouseVec <= 95 && parentMouseVec >= 80)
            {
                
                GameManager.Instance.Score++;
                gameObject.SetActive(false);
                GameManager.Instance.objectPool.Add(gameObject);
                GameManager.Instance.isSpawn = false;
                ayunAnimator.Good();
                Instantiate(speakStair,position);
            }
           
            yield return null;
        }
        
    }

}
