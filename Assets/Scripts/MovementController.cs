using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class MovementController : MonoBehaviour
{
    [field: SerializeField] public bool CanMove { get; set; } = true;
    [SerializeField] private GameObject surface;
    [SerializeField, Min(0f)] private float speed = 3.5f;
    [SerializeField, Min(0f)] private float jumpSpeed = 7f;
    [SerializeField, Min(0.01f)] private float gravity = 20f;
    [Tooltip("Velocidad máxima de caída.")]
    [SerializeField, Min(0f)] private float fallSpeed = 4f;

    private CharacterController controller;
    private SpriteRenderer spriteRenderer;
    private float verticalSpeed;
    private bool grounded;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        Vector3 center = controller.center;
        center.z = -controller.radius;
        controller.center = center;
    }

    public void SetSurface(GameObject newSurface, Transform spawnPoint)
    {
        surface = newSurface;
        verticalSpeed = 0f;
        grounded = false;

        Transform face = surface.transform;
        Vector3 position = spawnPoint.position + face.up * controller.skinWidth;

        controller.enabled = false;
        transform.SetPositionAndRotation(position, Quaternion.LookRotation(-face.up, face.forward));
        controller.enabled = true;
    }

    private void Update()
    {
        if (!CanMove || surface == null) return;

        float horizontal = InputSystem.actions.FindAction("Move").ReadValue<Vector2>().x;
        if (spriteRenderer != null && horizontal != 0f)
            spriteRenderer.flipX = horizontal < 0f;

        if (grounded && InputSystem.actions.FindAction("Jump").WasPressedThisFrame())
            verticalSpeed = jumpSpeed;

        verticalSpeed = Mathf.Max(verticalSpeed - gravity * Time.deltaTime, -fallSpeed);
        Vector3 velocity = transform.right * (horizontal * speed) + transform.up * verticalSpeed;
        grounded = false;
        controller.Move(velocity * Time.deltaTime);

        if (transform.up == Vector3.up)
            grounded = controller.isGrounded && verticalSpeed <= 0f;

        if (grounded)
            verticalSpeed = 0f;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        float upDot = Vector3.Dot(hit.normal, transform.up);
        float minGroundDot = Mathf.Max(0.001f, Mathf.Cos(controller.slopeLimit * Mathf.Deg2Rad));

        if (verticalSpeed <= 0f && upDot >= minGroundDot)
            grounded = true;
        else if (verticalSpeed > 0f && upDot <= -minGroundDot)
            verticalSpeed = 0f;
    }
}
