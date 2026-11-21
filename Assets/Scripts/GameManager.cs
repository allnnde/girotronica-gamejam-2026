using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Tooltip("Cara inicial de la partida. Durante el juego muestra la cara activa.")]
    [SerializeField] private Transform activeFace;
    [Tooltip("Punto de aparición en la primera cara.")]
    [SerializeField] private Transform firstSpawnPoint;
    [SerializeField] private MovementController player;

    public Transform ActiveFace => activeFace;
    public Transform FirstFace { get; private set; }

    private void Start()
    {
        FirstFace = activeFace;
        SetFace(FirstFace, firstSpawnPoint);
    }

    public void SetFace(Transform face, Transform spawnPoint)
    {
        activeFace = face;
        player.SetSurface(face.gameObject, spawnPoint);
    }
}
