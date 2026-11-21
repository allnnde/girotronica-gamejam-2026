using UnityEngine;

public class GoalZoneController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [Tooltip("Cara de destino. Vacío usa la primera cara de la partida.")]
    [SerializeField] private Transform targetFace;
    [Tooltip("Punto de aparición sobre la cara de destino.")]
    [SerializeField] private Transform targetSpawnPoint;
    [SerializeField, Min(0.01f)] private float delay = 0.15f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            Invoke(nameof(ChangeFace), delay);
    }

    private void ChangeFace()
    {
        if (targetFace != gameManager.ActiveFace)
            gameManager.SetFace(targetFace, targetSpawnPoint);
    }
}
