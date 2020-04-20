using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float waitTime;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, waitTime);
    }

    public void SelfDestroy()
    {
        Destroy(gameObject);
    }


}
