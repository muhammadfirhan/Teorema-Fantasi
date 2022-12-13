using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateCamera : MonoBehaviour
{
    public GameObject player;
    private Touch theTouch;

    private Vector2 touchStartPosition, touchEndPosition;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            theTouch = Input.GetTouch(0);

            if (theTouch.phase == TouchPhase.Began)
            {
                touchStartPosition = theTouch.position;
            }

            else if (theTouch.phase == TouchPhase.Moved || theTouch.phase == TouchPhase.Ended)
            {
                touchEndPosition = theTouch.position;

                float posX = touchEndPosition.x - touchStartPosition.x;
                float posY = touchEndPosition.y - touchStartPosition.y;

                if (Mathf.Abs(posX) == 0 && Mathf.Abs(posY) == 0)
                {
                    transform.Rotate(Vector3.up);
                    transform.Rotate(Vector3.right);
                    transform.position = player.transform.position;
                }

                else if (Mathf.Abs(posX) >= Mathf.Abs(posY))
                {
                    transform.Rotate(Vector3.up, posX * Time.deltaTime);
                    transform.position = player.transform.position;
                }

                else
                {
                    
                    transform.Rotate(Vector3.right, posY * Time.deltaTime);
                    transform.position = player.transform.position;
                }
            }
        }
    }
}
