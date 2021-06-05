using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public PlayerControl thePlayer;

    private Vector3 lastPlayerPosition;
    private float distanceToMove;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerControl>();   
        lastPlayerPosition = thePlayer.transform.position;  
    }

    // Update is called once per frame
    void Update()
    {
//distance for camera to move is equal to the distance in which the player moved.
        distanceToMove = thePlayer.transform.position.x - lastPlayerPosition.x;
//move the camera forward (by amount distanceToMove), y and z wont follow player, only x does. 
        transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);
        lastPlayerPosition = thePlayer.transform.position;    
    }
}
