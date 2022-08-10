using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARController : MonoBehaviour
{
    public GameObject CursorChildObject;
    public GameObject MyObject;
    public ARRaycastManager RaycastManager;
    public bool UseCursor = false;



    // Start is called before the first frame update
    void Start()
    {
        CursorChildObject.SetActive(UseCursor);
        //camera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {

        if (UseCursor)
        {
            UpdateCursor();
        }

       
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {

            if (UseCursor)
            {
                GameObject.Instantiate(MyObject, transform.position, transform.rotation);
            }
            else
            {
                List<ARRaycastHit> touches = new List<ARRaycastHit>();
                RaycastManager.Raycast(Input.GetTouch(0).position, touches, TrackableType.Planes);

                if (touches.Count > 0)
                {
                    GameObject.Instantiate(MyObject, touches[0].pose.position, new Quaternion(0,180,0,0));
                }
            }
        }
    }

    private void UpdateCursor()
    {
        Vector2 screenPosition = Camera.main.ViewportToScreenPoint(new Vector2(0.5f, 0.5f));
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        RaycastManager.Raycast(screenPosition, hits, TrackableType.Planes);


        if (hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;
        }
    }
}
