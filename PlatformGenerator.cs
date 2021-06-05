using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject thePlatform;
    public Transform generationPoint;
    public float platformGap;
    public float platformRotate;

    private float platformWidth;

    public float minGap;
    public float maxGap;
    public float minRotate;
    public float maxRotate;

    // Start is called before the first frame update
    void Start()
    {
        platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < generationPoint.position.x){
            var clone = thePlatform;
            platformRotate = Random.Range(minRotate, maxRotate);
            platformGap = Random.Range(minGap, maxGap);
            transform.position = new Vector3(transform.position.x + platformWidth + platformGap, transform.position.y, transform.position.z);
            transform.rotation = Quaternion.Euler(Vector3.forward * platformRotate);
            clone = Instantiate(thePlatform, transform.position, transform.rotation);
            clone.tag = "platform";        }
    }
}
