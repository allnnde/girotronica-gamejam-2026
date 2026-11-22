using UnityEngine;

public class GoalZoneController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [Tooltip("Cara de destino. Vacío usa la primera cara de la partida.")]
    [SerializeField] private Transform targetFace;
    [Tooltip("Cara a la que gira el cubo al alcanzar esta meta.")]
    [SerializeField] private Faces cubeFace;
    [Tooltip("Cielo de la cara de destino al completar el giro.")]
    [SerializeField] private FaceSkybox targetSkybox = FaceSkybox.Day;
    [Tooltip("Punto de aparición sobre la cara de destino.")]
    [SerializeField] private Transform targetSpawnPoint;
    [SerializeField, Min(0.01f)] private float delay = 0.15f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            gameManager.SetFace(targetFace, targetSpawnPoint, cubeFace, delay, targetSkybox);
    }
}
