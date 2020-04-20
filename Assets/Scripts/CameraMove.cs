using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Vector3 maxPos;
    public Vector3 minPos;

    public bool bounds;

    public float speed;
    Vector3 movement;

    CameraZoom camZoom;


    // Start is called before the first frame update
    void Start()
    {
        camZoom = GetComponent<CameraZoom>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = camZoom.cam.orthographicSize *2 ;

        movement.x = Input.GetAxisRaw("Horizontal") * speed;
        movement.y = Input.GetAxisRaw("Vertical") * speed;

        transform.position += movement * Time.deltaTime;

        if (bounds)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minPos.x, maxPos.x),
                Mathf.Clamp(transform.position.y, minPos.y, maxPos.y),
                Mathf.Clamp(transform.position.z, minPos.z, maxPos.z));
        }
    }
}
