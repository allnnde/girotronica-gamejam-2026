using UnityEngine;

public class GoalZoneController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [Tooltip("Cara de destino. Su eje Y apunta hacia fuera del cubo y su eje Z marca la vertical del nivel.")]
    [SerializeField] private Transform targetFace;
    [Tooltip("Cielo de la cara de destino al completar el giro.")]
    [SerializeField] private FaceSkybox targetSkybox = FaceSkybox.Day;
    [Tooltip("Punto de aparición sobre la cara de destino.")]
    [SerializeField] private Transform targetSpawnPoint;
    [SerializeField, Min(0.01f)] private float delay = 0.15f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            gameManager.SetFace(targetFace, targetSpawnPoint, delay, targetSkybox);
    }
}
