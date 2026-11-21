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

    private bool isChangingFace;

    public Transform ActiveFace => activeFace;
    public Transform FirstFace { get; private set; }

    private void Start()
    {
        FirstFace = activeFace;
        player.SetSurface(FirstFace.gameObject, firstSpawnPoint);
    }

    public void SetFace(Transform face, Transform spawnPoint, Faces cubeFace, float delay)
    {
        if (isChangingFace || face == activeFace) return;

        isChangingFace = true;
        StartCoroutine(ChangeFaceAfterDelay(face, spawnPoint, cubeFace, delay));
    }

    private IEnumerator ChangeFaceAfterDelay(Transform face, Transform spawnPoint, Faces cubeFace, float delay)
    {
        yield return new WaitForSeconds(delay);
        activeFace = face;
        player.gameObject.SetActive(false);
        cubeController.SetFace(cubeFace);
        yield return new WaitUntil(cubeController.FinishRotation);
        player.gameObject.SetActive(true);
        player.SetSurface(face.gameObject, spawnPoint);
        player.FadeIn();
        isChangingFace = false;
    }
}
