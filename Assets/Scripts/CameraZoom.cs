using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraZoom : MonoBehaviour
{
    [HideInInspector]
    public Camera cam;

    public float maxZoom;
    public float minZoom;


    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        var scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll > 0f)
        {
            if (cam.orthographicSize <= minZoom)
            {
                cam.orthographicSize = minZoom;
            }
            else
            {
                cam.orthographicSize -= 1;

            }
        }
        else if (scroll < 0f)
        {


            if (cam.orthographicSize >= maxZoom)
            {
                cam.orthographicSize = maxZoom;
            }
            else
            {
                cam.orthographicSize += 1;

            }
           
        }
    }
}
