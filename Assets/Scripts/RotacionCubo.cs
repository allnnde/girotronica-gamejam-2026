using System;
using UnityEngine;
using UnityEngine.InputSystem;

public enum Faces{X, mX, Y, mY, Z, mZ}

public class PlayerController_lite : MonoBehaviour
{
    public GameObject CubeMap;
    private bool rotate;
    private float time;
    public float speed = 1;
    [SerializeField] private Faces faces;
    private Faces savedFaces;
    private Quaternion startRot;
    private bool startRotAssigned;
    void Start(){savedFaces = faces;}
    void Update(){if(faces != savedFaces || rotate){savedFaces = faces; rotate = true; AnimateRotation(faces);}}
    public void AnimateRotation(Faces f)
    {
        if(!startRotAssigned){startRot = CubeMap.transform.rotation;}
        time += Time.deltaTime / speed; 
        time = Mathf.Clamp01(time);
        CubeMap.transform.rotation = Quaternion.Lerp(startRot, f == Faces.X ? Quaternion.Euler(90,0,0) : f == Faces.mX ? Quaternion.Euler(-90,0,0) : f == Faces.Y ? Quaternion.Euler(0,90,0) : f == Faces.mY ? Quaternion.Euler(0,-90,0) : f == Faces.Z ? Quaternion.Euler(0,0,90) : Quaternion.Euler(0,0,-90), time);
        if(time == 1){rotate = false; time = 0;}
    }
}
