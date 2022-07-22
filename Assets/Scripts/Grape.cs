using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grape : MonoBehaviour
{
    [SerializeField] private Transform mount;

    private Vector2 originalPos;


    //calculate offset between center of gameobject and touch position
    private float deltaX, deltaY;

    //true when gameobject is dropped in correct place
    public static bool locked;
    // Start is called before the first frame update
    void Start()
    {
        //Banana to appear in original spawn point
        originalPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && !locked)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPoint = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {
                //when screen is just touched
                case TouchPhase.Began:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPoint))//if banana is touched calculate offset between touc position and center of bear game object for smooth dragging
                    {
                        deltaX = touchPoint.x - transform.position.x;
                        deltaY = touchPoint.y - transform.position.y;
                    }
                    break;

                //if moving finger on the screen, banana position will be set to touch position accounting for offset
                case TouchPhase.Moved:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPoint))
                    {
                        transform.position = new Vector2(touchPoint.x - deltaX, touchPoint.y - deltaY);
                    }
                    break;

                //if finger has been released, check if it's in the right place(or close enough). If it isn't, return to original position
                case TouchPhase.Ended:
                    if (Mathf.Abs(transform.position.x - mount.position.x) <= 0.5f && Mathf.Abs(transform.position.y - mount.position.y) <= 0.5f)
                    {
                        transform.position = new Vector2(mount.position.x, mount.position.y);
                        locked = true;
                    }
                    else
                    {
                        transform.position = new Vector2(originalPos.x, originalPos.y);
                    }
                    break;
            }
        }
    }
}
