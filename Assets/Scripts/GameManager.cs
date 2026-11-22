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

    private Material transitionSkybox;
    private bool isChangingFace;

    public Transform ActiveFace => activeFace;
    public Transform FirstFace { get; private set; }

    private void Start()
    {
        ApplySkybox(daySkybox);
        FirstFace = activeFace;
        player.SetSurface(FirstFace.gameObject, firstSpawnPoint);
    }

    public void SetFace(Transform face, Transform spawnPoint, Faces cubeFace, float delay, FaceSkybox skybox)
    {
        if (isChangingFace || face == activeFace) return;

        isChangingFace = true;
        StartCoroutine(ChangeFaceAfterDelay(face, spawnPoint, cubeFace, delay, skybox));
    }

    private IEnumerator ChangeFaceAfterDelay(Transform face, Transform spawnPoint, Faces cubeFace, float delay, FaceSkybox skybox)
    {
        yield return new WaitForSeconds(delay);
        activeFace = face;
        player.gameObject.SetActive(false);
        cubeController.SetFace(cubeFace);

        Material source = RenderSettings.skybox;
        Material target = skybox == FaceSkybox.Night ? nightSkybox : daySkybox;
        if (source != null && target != null && source != target && source.shader == target.shader && cubeController.speed > 0f)
        {
            if (transitionSkybox == null) transitionSkybox = new Material(source);
            transitionSkybox.CopyPropertiesFromMaterial(source);
            RenderSettings.skybox = transitionSkybox;

            float elapsed = 0f;
            while (!cubeController.FinishRotation())
            {
                yield return null;
                elapsed += Time.deltaTime;
                float duration = cubeController.speed;
                float progress = duration > 0f ? Mathf.Clamp01(elapsed / duration) : 1f;
                transitionSkybox.Lerp(source, target, progress);
            }
        }
        else
        {
            yield return new WaitUntil(cubeController.FinishRotation);
        }
        ApplySkybox(target);
        player.gameObject.SetActive(true);
        player.SetSurface(face.gameObject, spawnPoint);
        player.FadeIn();
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
