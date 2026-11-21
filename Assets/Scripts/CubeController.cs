using System;
using UnityEngine;
using UnityEngine.InputSystem;

public enum Faces { X, mX, Y, mY, Z, mZ }

public class CubeController : MonoBehaviour
{
    public GameObject CubeMap;
    private bool rotate;
    private float elapsedSeconds;
    [Tooltip("Duración del giro en segundos.")]
    public float speed = 1;
    [SerializeField] private Faces faces;
    private Faces savedFaces;
    private Quaternion startRot;

    public void SetFace(Faces face)
    {
        faces = face;
    }

    public bool FinishRotation() => faces == savedFaces && !rotate;

    void Awake() { savedFaces = faces; }
    void Update()
    {
        if (faces != savedFaces || rotate)
            AnimateRotation(faces);
    }

    public void AnimateRotation(Faces face)
    {
        if (!rotate || face != savedFaces)
        {
            faces = face;
            savedFaces = face;
            startRot = CubeMap.transform.rotation;
            elapsedSeconds = 0f;
        }

        Quaternion target = face switch
        {
            Faces.X => Quaternion.Euler(-90, 0, 90),
            Faces.mX => Quaternion.Euler(-90, 0, -90),
            Faces.mY => Quaternion.Euler(0, 90, 90),
            Faces.Z => Quaternion.Euler(180, 0, -180),
            Faces.mZ => Quaternion.Euler(0, 0, 0),
            _ => Quaternion.identity
        };

        elapsedSeconds += Time.deltaTime;
        float progress = speed > 0f ? Mathf.Clamp01(elapsedSeconds / speed) : 1f;
        CubeMap.transform.rotation = Quaternion.Slerp(startRot, target, progress);
        rotate = progress < 1f;
    }
}
