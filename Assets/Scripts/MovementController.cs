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
    public bool Invertir;

    [Header("Sonidos")]
    public AudioClip caminar;
    public AudioClip saltar;
    public AudioClip aterrizaje;
    public bool grounded;

    private Rigidbody body;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioJugador;
    private float horizontal;
    private bool audioIsPlaying;
    private bool jumped;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        audioJugador = transform.Find("Audio Source").GetComponent<AudioSource>();
        if (audioJugador.playOnAwake) audioJugador.playOnAwake = false;
    }

    public void SetSurface(GameObject newSurface, Transform spawnPoint)
    {
        surface = newSurface;
        Transform face = surface.transform;
        body.rotation = Quaternion.LookRotation(-face.up, face.forward);
        body.position = spawnPoint.position + face.up * 0.04f;
        body.linearVelocity = Vector3.zero;
        horizontal = 0f;
        grounded = false;
    }

    public void SetOpacity(float alpha)
    {
        Color color = spriteRenderer.color;
        color.a = alpha;
        spriteRenderer.color = color;
    }

    public void FadeIn()
    {
        StartCoroutine(FadeInSprite());
    }

    private IEnumerator FadeInSprite()
    {
        const float fadeInDuration = 0.25f;
        float opacity = 0f;
        SetOpacity(opacity);
        while (opacity < 1f)
        {
            yield return null;
            opacity = Mathf.MoveTowards(opacity, 1f, Time.deltaTime / fadeInDuration);
            SetOpacity(opacity);
        }
    }

    private void Update()
    {
        if (!CanMove || surface == null) return;

        horizontal = InputSystem.actions.FindAction("Move").ReadValue<Vector2>().x;

        if (audioIsPlaying && (!grounded || horizontal == 0f))
        {
            audioJugador.Stop();
            audioJugador.loop = false;
            audioIsPlaying = false;
        }
        else if (spriteRenderer != null && horizontal != 0f)
        {
            spriteRenderer.flipX = horizontal < 0f;
            if (!audioIsPlaying)
            {
                audioJugador.clip = caminar;
                audioJugador.loop = true;
                audioJugador.Play();
                audioIsPlaying = true;
            }
        }

        if (grounded && InputSystem.actions.FindAction("Jump").WasPressedThisFrame())
        {
            body.linearVelocity = (Invertir == true ? -transform.right : transform.right) * (horizontal * speed) + transform.up * jumpSpeed;
            grounded = false;
            if (!audioIsPlaying)
            {
                audioJugador.clip = saltar;
                audioJugador.Play();
                jumped = true;
            }
        }
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
        body.linearVelocity =  (Invertir == true ? -transform.right : transform.right) * (horizontal * speed) + up * verticalSpeed;
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
            if (jumped)
            {
                audioJugador.clip = aterrizaje;
                audioJugador.Play();
                jumped = false;
            }
            break;
        }
    }
}
