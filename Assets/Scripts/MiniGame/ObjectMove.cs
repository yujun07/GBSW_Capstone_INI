using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    bool velo;
    
    
    IEnumerator Move()
    {
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        Vector3 dirVec = Vector3.left;
        if(rigid.velocity.x > -10 && !velo)
        {
            
            rigid.AddForce(dirVec.normalized * 0.03f, ForceMode2D.Impulse);
        }
        else
        {
            velo = true;
        }
        if(rigid.velocity.x < 0 && velo)
        {
            rigid.velocity = Vector3.zero;
        }
        yield return null;
    }
    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Move());
    }
}
