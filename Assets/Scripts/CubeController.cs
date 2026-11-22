using UnityEngine;

public class CubeController : MonoBehaviour
{
    public GameObject CubeMap;
    [Tooltip("Duración del giro en segundos.")]
    public float speed = 1;

    public float RotationProgress { get; private set; } = 1f;
    private float elapsedSeconds;
    private Quaternion initialFaceRotation;
    private Quaternion startRotation;
    private Quaternion targetRotation;

    public void SetInitialFace(Transform face)
    {
        initialFaceRotation = face.rotation;
    }

    public void SetFace(Transform face, bool upsideDown)
    {
        startRotation = CubeMap.transform.rotation;
        Quaternion presentation = initialFaceRotation;
        if (upsideDown) presentation *= Quaternion.AngleAxis(180f, Vector3.up);
        targetRotation = presentation * Quaternion.Inverse(face.rotation) * startRotation;
        elapsedSeconds = 0f;
        RotationProgress = 0f;
    }

    public bool FinishRotation() => RotationProgress >= 1f;

    private void Update()
    {
        if (FinishRotation()) return;
        elapsedSeconds += Time.deltaTime;
        float progress = speed > 0f ? Mathf.Clamp01(elapsedSeconds / speed) : 1f;
        RotationProgress = Mathf.SmoothStep(0f, 1f, progress);
        CubeMap.transform.rotation = Quaternion.Slerp(startRotation, targetRotation, RotationProgress);
    }
}
