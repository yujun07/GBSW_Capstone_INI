using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AyunAnimator : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Good()
    {
        StartCoroutine("GoodAfterWait");
    }

    IEnumerator GoodAfterWait()
    {
        animator.SetBool("good", true);
        yield return new WaitForSeconds(0.2f);
        animator.SetBool("good", false);

    }

    public void Bad()
    {
 
        StartCoroutine("BadAfterWait");

    }

    IEnumerator BadAfterWait()
    {
        animator.SetBool("bad", true);
        yield return new WaitForSeconds(0.2f);
        animator.SetBool("bad", false);
    }
}
