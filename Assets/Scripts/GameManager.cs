using System.Collections;
using UnityEngine;

public enum FaceSkybox { Day, Night }

public class GameManager : MonoBehaviour
{
    [Tooltip("Cara inicial de la partida. Durante el juego muestra la cara activa.")]
    [SerializeField] private Transform activeFace;
    [Tooltip("Punto de aparición en la primera cara.")]
    [SerializeField] private Transform firstSpawnPoint;
    [SerializeField] private MovementController player;
    [SerializeField] private CubeController cubeController;
    [SerializeField] private Material daySkybox;
    [SerializeField] private Material nightSkybox;
    [Tooltip("Gira las caras nocturnas 180°. El movimiento sigue los ejes locales de la cara.")]
    [SerializeField] private bool invertNightFaces;

    private Material transitionSkybox;
    private bool isChangingFace;

    public Transform ActiveFace => activeFace;
    public Transform FirstFace { get; private set; }

    private void Start()
    {
        ApplySkybox(daySkybox);
        FirstFace = activeFace;
        cubeController.SetInitialFace(FirstFace);
        player.SetSurface(FirstFace.gameObject, new Vector3(firstSpawnPoint.transform.position.x, firstSpawnPoint.transform.position.y, firstSpawnPoint.transform.position.z - firstSpawnPoint.transform.localScale.z/2));
    }

    public void SetFace(Transform face, Transform spawnPoint, float delay, FaceSkybox skybox)
    {
        if (isChangingFace || face == activeFace) return;

        isChangingFace = true;
        StartCoroutine(ChangeFaceAfterDelay(face, spawnPoint, delay, skybox));
    }

    private IEnumerator ChangeFaceAfterDelay(Transform face, Transform spawnPoint, float delay, FaceSkybox skybox)
    {
        yield return player.FadeTo(0f, delay);
        Vector3 departure = player.transform.position;
        activeFace = face;
        player.gameObject.SetActive(false);
        bool upsideDown = invertNightFaces && skybox == FaceSkybox.Night;
        cubeController.SetFace(face, upsideDown);

        Material source = RenderSettings.skybox;
        Material target = skybox == FaceSkybox.Night ? nightSkybox : daySkybox;
        bool blendSky = source != null && target != null && source != target && source.shader == target.shader && cubeController.speed > 0f;
        if (blendSky)
        {
            if (transitionSkybox == null) transitionSkybox = new Material(source);
            transitionSkybox.CopyPropertiesFromMaterial(source);
            RenderSettings.skybox = transitionSkybox;
        }

        while (!cubeController.FinishRotation())
        {
            yield return null;
            float progress = cubeController.RotationProgress;
            // Cinemachine sigue este Transform también mientras el jugador está desactivado.
            player.transform.position = Vector3.Lerp(departure, spawnPoint.position, progress);
            if (blendSky) transitionSkybox.Lerp(source, target, progress);
        }
        ApplySkybox(target);
        player.gameObject.SetActive(true);
        player.SetSurface(face.gameObject, spawnPoint.position);
        player.FadeTo(1f, 0.45f);
        isChangingFace = false;
    }

    private void ApplySkybox(Material material)
    {
        if (material == null || RenderSettings.skybox == material) return;

        RenderSettings.skybox = material;
        DynamicGI.UpdateEnvironment();
    }

    private void OnDestroy()
    {
        if (transitionSkybox == null) return;
        if (RenderSettings.skybox == transitionSkybox) RenderSettings.skybox = daySkybox;
        Destroy(transitionSkybox);
    }
}
