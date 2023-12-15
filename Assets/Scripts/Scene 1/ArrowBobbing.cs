using UnityEngine;

public class ArrowBobbing : MonoBehaviour
{
    public float bobbingHeight = 0.5f; // Maximum bobbing height
    public float bobbingSpeed = 2.0f; // Speed of bobbing

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Calculate the vertical bobbing movement using a sine wave
        float yOffset = Mathf.Sin(Time.time * bobbingSpeed) * bobbingHeight;

        // Update the arrow's position with bobbing effect
        transform.position = startPosition + Vector3.up * yOffset;
    }
}
