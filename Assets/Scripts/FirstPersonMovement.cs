using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FirstPersonMovement : MonoBehaviour
{
    const string HorizontalAxis = "Horizontal";
    const string VerticalAxis = "Vertical";
    const string MouseHorizontalAxis = "Mouse X";
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float extraGravity;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private float shootingSenstivityMultiplier;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    private void Update()
    {
        //Rotation
        float delta = Input.GetAxis(MouseHorizontalAxis) * rotateSpeed * (Input.GetMouseButton(0) ? shootingSenstivityMultiplier : 1f);
        transform.rotation = Quaternion.Euler(Vector3.up * delta) * transform.rotation;

        //Jumping
        bool grounded = Physics.Raycast(transform.position, Vector3.down, GetComponent<CapsuleCollider>().height / 2.0f + 0.05f, groundLayer);

        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        Vector3 movementVector = Vector3.zero;
        movementVector.x = Input.GetAxisRaw(HorizontalAxis);
        movementVector.z = Input.GetAxisRaw(VerticalAxis);
        movementVector.Normalize();
        movementVector = transform.rotation * movementVector;
        movementVector *= moveSpeed;
        movementVector.y = rb.velocity.y;
        rb.velocity = movementVector;
        rb.velocity += Vector3.down * extraGravity * Time.fixedDeltaTime;
    }
}
