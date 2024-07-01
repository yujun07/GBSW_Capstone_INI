using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    private float FirstTouchX;
    private float FirstTouchY;
    private float LastTouchX;
    private float LastTouchY;

    public float mouseVec;
    
    
    
    public float GetMouseVec()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FirstTouchX = Input.mousePosition.x;
            FirstTouchY = Input.mousePosition.y;
        }

        if (Input.GetMouseButtonUp(0))
        {
            LastTouchX = Input.mousePosition.x;
            LastTouchY = Input.mousePosition.y;

            mouseVec = Mathf.Atan2(LastTouchY - FirstTouchY, LastTouchX - FirstTouchX) * Mathf.Rad2Deg;
            Debug.Log(mouseVec.ToString());
        }
        return mouseVec;
    }
    
    public void Update()
    {
        GetMouseVec();
    }

    
    
}
