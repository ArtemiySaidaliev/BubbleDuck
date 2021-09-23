using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchManagerMenu : MonoBehaviour
{
    
    private Vector2 startTouchPosition;
    private Vector2 currentTouchPosition;
    private Vector2 endTouchPosition;
    private bool stopTouch = false;

    public float swipeRange;
    public float tapRange;
    ////////////////////////////////////////
    public string SceneUp;
    
    public void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait; 
        Debug.Log("Screen Width : " + Screen.width);
    }
    

    public int Swipe()
    {
        int input = 3;
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }

        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            currentTouchPosition = Input.GetTouch(0).position;
            Vector2 Distance = currentTouchPosition - startTouchPosition;

            if(!stopTouch)
            {
                if(Distance.y > swipeRange)
                {
                    Debug.Log("Up");
                    input = 0;
                    return input;
                    
                }
                else if(Distance.y < -swipeRange)
                {
                    Debug.Log("Down");
                    input = 1;
                    return input;
                }
            }
        }
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            stopTouch = false;
            endTouchPosition = Input.GetTouch(0).position;
            Vector2 Distance = endTouchPosition - startTouchPosition;

          if(Mathf.Abs(Distance.x) < tapRange && Mathf.Abs(Distance.y) < tapRange)
            {
                Debug.Log("TAP");
                input = 2;
                return input;
            }
        
        }
        return input;
    }


}
