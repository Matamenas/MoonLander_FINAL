using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* INTRO: The purpose of this script is for the camera to be able to follow
and track the player's position and rotation. Previously, we only every covered
allowing the camera to track the player's position but no rotation.
*/
public class FollowPlayer : MonoBehaviour {
    //Instead of creating a GameObject, we need to use a reference to the Transform component of our Player
    public Transform player;

    /* Similarly to our Prototype 1, we create a private variable called 'offset'
    that allow us to specify a specific offset for our camera. This means that
    our camera is positioned 4 'y' units above the car, and -7 'z' units
    behind our car. */
    private Vector3 offset = new Vector3(0, 4, -8);

    /* This 'smoothSpeed' variable allows us to control at what speed the camera
    is going to follow the player */
    public float smoothSpeed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //We create a local Vector3 called 'desiredPosition' whose purpose is to calculte the desired camera's position
        //It is equal to our player's position + we call a method called 'TransformDirection' and set our desired camera offset as an argument
        Vector3 desiredPosition = player.position + player.TransformDirection(offset);

        /* We create another local Vector3 called 'smoothedPosition' whose purpose is to basically math the camera's position
        to the desired position, which we set in our offset.
        - It is equal to a 'Lerp' function so that we are able to move our camera gradually towards
         the player's position.*/
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        //We also need to set our camera's position to our Vector3 called 'smoothedPosition'
        transform.position = smoothedPosition;

        /* Lastly, we need to use a function called 'LookAt' that is in charge
        of pointing at our target position which is that of the player
        - We then pass our player as an argument as stated above */
        transform.LookAt(player);
    }
}
