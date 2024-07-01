using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : GameController
{
    AyunAnimator ayunAnimator;
    public GameObject speak;
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
        
        while(true)
        {
            float parentMouseVec = GetMouseVec();
            
            if (parentMouseVec <= 15 &&  parentMouseVec >= -15 && parentMouseVec != 0)
            {
                GameManager.Instance.Score++;
                gameObject.SetActive(false);
                GameManager.Instance.objectPool.Add(gameObject);
                GameManager.Instance.isSpawn = false;
                ayunAnimator.Good();
                Instantiate(speak);
            }
            
            yield return null;
        }
        
    }
    
}
