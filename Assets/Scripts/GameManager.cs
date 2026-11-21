using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Tooltip("Cara inicial de la partida. Durante el juego muestra la cara activa.")]
    [SerializeField] private Transform activeFace;
    [Tooltip("Punto de aparición en la primera cara.")]
    [SerializeField] private Transform firstSpawnPoint;
    [SerializeField] private MovementController player;
    [SerializeField] private CubeController cubeController;

    public Transform ActiveFace => activeFace;
    public Transform FirstFace { get; private set; }

    private void Start()
    {
        FirstFace = activeFace;
        player.SetSurface(FirstFace.gameObject, firstSpawnPoint);
    }

    public void SetFace(Transform face, Transform spawnPoint, Faces cubeFace)
    {
        activeFace = face;
        cubeController.SetFace(cubeFace);
        StartCoroutine(SpawnAfterRotation(face, spawnPoint));
    }

    private IEnumerator SpawnAfterRotation(Transform face, Transform spawnPoint)
    {
        yield return new WaitUntil(cubeController.FinishRotation);
        player.SetSurface(face.gameObject, spawnPoint);
    }
}
