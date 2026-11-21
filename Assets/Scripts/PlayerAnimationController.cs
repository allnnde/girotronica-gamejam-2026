using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;
    private MovementController movement;
    private Rigidbody body;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        movement = GetComponent<MovementController>();
        body = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float horizontalSpeed = Vector3.Dot(body.linearVelocity, transform.right);
        bool walking = movement.CanMove && movement.grounded && Mathf.Abs(horizontalSpeed) > 0.01f;
        animator.SetBool("IsWalking", walking);
    }
}
