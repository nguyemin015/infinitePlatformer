using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDelete : MonoBehaviour
{

    public GameObject platformDeletePoint;

    // Start is called before the first frame update
    void Start()
    {
        platformDeletePoint = GameObject.Find("deletePlatforms");
    }

    // Update is called once per frame
    void Update()
    {
        //if point of character is greater than delete point, then delete platform.
        if(transform.position.x < platformDeletePoint.transform.position.x) 
        {
            Destroy(gameObject);
        }
    }
}
