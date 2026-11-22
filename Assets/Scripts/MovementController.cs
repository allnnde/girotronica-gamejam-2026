using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
public class MovementController : MonoBehaviour
{
    [field: SerializeField] public bool CanMove { get; set; } = true;
    [SerializeField] private GameObject surface;
    [SerializeField, Min(0f)] private float speed = 3.5f;
    [SerializeField, Min(0f)] private float jumpSpeed = 7f;
    [SerializeField, Min(0.01f)] private float gravity = 20f;
    [Tooltip("Velocidad máxima de caída.")]
    [SerializeField, Min(0f)] private float fallSpeed = 4f;

    [Header("Sonidos")]
    public AudioClip caminar;
    public AudioClip saltar;
    public AudioClip aterrizaje;
    public bool grounded;
    public bool IsJumping { get; private set; }
    public float JumpProgress { get; private set; }

    private Rigidbody body;
    private SpriteRenderer spriteRenderer;
    private Coroutine opacityFade;
    private AudioSource audioJugador;
    private float horizontal;
    private bool hasTouchedGround;
    private bool landingPending;
    private float jumpStartHeight;
    private float jumpPeakHeight;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        audioJugador = transform.Find("Audio Source").GetComponent<AudioSource>();
        if (audioJugador.playOnAwake) audioJugador.playOnAwake = false;
    }

    public void SetSurface(GameObject newSurface, Vector3 spawnPoint)
    {
        surface = newSurface;
        Transform face = surface.transform;
        body.rotation = Quaternion.LookRotation(-face.up, face.forward);
        body.position = spawnPoint+ face.up * 0.04f;
        body.linearVelocity = Vector3.zero;
        horizontal = 0f;
        grounded = false;
        IsJumping = false;
        hasTouchedGround = false;
        landingPending = false;
        audioJugador.Stop();
        audioJugador.loop = false;
    }

    private void SetOpacity(float alpha)
    {
        Color color = spriteRenderer.color;
        color.a = alpha;
        spriteRenderer.color = color;
    }

    public Coroutine FadeTo(float targetAlpha, float duration)
    {
        if (opacityFade != null) StopCoroutine(opacityFade);
        opacityFade = StartCoroutine(FadeSprite(targetAlpha, duration));
        return opacityFade;
    }

    private IEnumerator FadeSprite(float targetAlpha, float duration)
    {
        float startAlpha = spriteRenderer.color.a;
        for (float elapsed = 0f; elapsed < duration; elapsed += Time.deltaTime)
        {
            SetOpacity(Mathf.SmoothStep(startAlpha, targetAlpha, elapsed / duration));
            yield return null;
        }
        SetOpacity(targetAlpha);
        opacityFade = null;
    }

    private void Update()
    {
        if (!CanMove || surface == null)
        {
            UpdateFootsteps(false);
            return;
        }

        horizontal = InputSystem.actions.FindAction("Move").ReadValue<Vector2>().x;

        if (spriteRenderer != null && horizontal != 0f)
            spriteRenderer.flipX = horizontal < 0f;

        if (grounded && InputSystem.actions.FindAction("Jump").WasPressedThisFrame())
        {
            body.linearVelocity = transform.right * (horizontal * speed) + transform.up * jumpSpeed;
            grounded = false;
            IsJumping = true;
            JumpProgress = 0f;
            jumpStartHeight = Vector3.Dot(body.position, transform.up);
            jumpPeakHeight = jumpStartHeight;
            PlayMovementClip(saltar);
        }

        UpdateFootsteps(grounded && horizontal != 0f);
    }

    private void UpdateFootsteps(bool walking)
    {
        if (walking && !audioJugador.isPlaying && caminar != null)
        {
            audioJugador.clip = caminar;
            audioJugador.loop = true;
            audioJugador.Play();
        }
        else if (!walking && audioJugador.loop)
        {
            audioJugador.Stop();
            audioJugador.loop = false;
        }
    }

    private void PlayMovementClip(AudioClip clip)
    {
        if (clip == null) return;
        audioJugador.loop = false;
        audioJugador.clip = clip;
        audioJugador.Play();
    }

    private void FixedUpdate()
    {
        if (!CanMove || surface == null)
        {
            body.linearVelocity = Vector3.zero;
            return;
        }

        Vector3 up = transform.up;
        float verticalSpeed = Vector3.Dot(body.linearVelocity, up);
        verticalSpeed = Mathf.Max(verticalSpeed - gravity * Time.fixedDeltaTime, -fallSpeed);
        body.linearVelocity = transform.right * (horizontal * speed) + up * verticalSpeed;
        if (IsJumping)
        {
            float height = Vector3.Dot(body.position, up);
            jumpPeakHeight = Mathf.Max(jumpPeakHeight, height);
            // La cima corresponde a la mitad del clip de salto.
            JumpProgress = verticalSpeed > 0f
                ? 0.5f * Mathf.InverseLerp(jumpSpeed, 0f, verticalSpeed)
                : 0.5f + 0.5f * Mathf.InverseLerp(jumpPeakHeight, jumpStartHeight, height);
        }
        // grounded todavía representa los contactos del paso anterior.
        if (hasTouchedGround && !grounded)
            landingPending = true;
        grounded = false; // Los contactos de este paso lo vuelven a marcar.
    }

    private void OnCollisionEnter(Collision collision)
    {
        DetectGround(collision);
    }

    private void OnCollisionStay(Collision collision)
    {
        DetectGround(collision);
    }

    private void DetectGround(Collision collision)
    {
        for (int i = 0; i < collision.contactCount; i++)
        {
            Vector3 normal = collision.GetContact(i).normal;
            if (Vector3.Dot(normal, transform.up) < 0.7071f) continue; // 45 grados.
            if (Vector3.Dot(body.linearVelocity, normal) > 0.1f) continue;

            grounded = true;
            IsJumping = false;
            hasTouchedGround = true;
            if (landingPending)
            {
                landingPending = false;
                if (CanMove) PlayMovementClip(aterrizaje);
            }
            break;
        }
    }
}
