using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Tooltip("Cara que queda detrás del personaje en el plano de juego.")]
    [SerializeField] private Transform activeFace;
    [SerializeField] private MovementController player;

    private Transform appliedFace;

    public Transform ActiveFace => activeFace;

    private void Update()
    {
        if (activeFace != appliedFace) 
            SetFace(activeFace);
    }

    public void SetFace(Transform face)
    {
        activeFace = face;
        appliedFace = face;
        player.SetSurface(face != null ? face.gameObject : null);
    }
}
