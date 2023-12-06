using UnityEngine;

public class SimpleFPSController : MonoBehaviour
{
    public float mouseSensitivity = 2.0f;
    public float walkSpeed = 5.0f;
    public float sprintSpeed = 10.0f; // New sprint speed
    public float bobbingSpeed = 6f;
    public float sprintBobbingSpeed = 8f; // New bobbing speed for sprinting
    public float bobbingAmount = 0.06f;
    public float jumpForce = 5.0f;

    private Camera playerCamera;
    private Vector3 originalCameraPosition;
    private float timer = 0.0f;
    private Rigidbody rb;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        playerCamera = GetComponentInChildren<Camera>();
        originalCameraPosition = playerCamera.transform.localPosition;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;  // Freeze rotation to prevent unwanted rotation
    }

    void Update()
    {
        HandleMouseLook();
        HandleMovement();
        HandleHeadBobbing();
        HandleJump();
    }

    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.Rotate(Vector3.up * mouseX);

        float newRotationX = playerCamera.transform.localRotation.eulerAngles.x - mouseY;
        newRotationX = Mathf.Clamp(newRotationX, -90f, 90f);

        playerCamera.transform.localRotation = Quaternion.Euler(newRotationX, 0, 0);
    }

    void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        bool isSprinting = Input.GetKey(KeyCode.LeftShift); // Check if Left Shift is pressed for sprinting

        float speed = isSprinting ? sprintSpeed : walkSpeed; // Use sprint speed if sprinting, otherwise use walk speed

        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;
        Vector3 moveAmount = direction * speed * Time.deltaTime;

        transform.Translate(moveAmount);
    }

    void HandleHeadBobbing()
    {
        float currentBobbingSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintBobbingSpeed : bobbingSpeed; // Use sprint bobbing speed if sprinting, otherwise use regular bobbing speed

        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f || Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f)
        {
            timer += Time.deltaTime * currentBobbingSpeed;

            // Only apply bobbing along the Y-axis
            float bobbingAmountY = Mathf.Sin(timer) * bobbingAmount;

            playerCamera.transform.localPosition = originalCameraPosition + new Vector3(0, bobbingAmountY, 0);
        }
        else
        {
            timer = 0.0f;
            playerCamera.transform.localPosition = originalCameraPosition;
        }
    }

    void HandleJump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
