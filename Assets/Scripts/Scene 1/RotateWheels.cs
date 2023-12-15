using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWheels : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /* Basic movement for the child objects of the car
         - We want the wheels to rotate forward, but due to the wheel object's
        rotation, we are going to have to set our Vector3 to right.
         - The reason we use a Vector3 is because if we used the transform, when
         the car changed its orientation, it wouldn't adapt to the car's orientation
         - We set the Rotation Speed to 25 which is more accurate considering its a vehicle
         - Last but not least, we apply this script for all 4 wheel child components
        */
        transform.Rotate(Vector3.right, 25);
    }
}
