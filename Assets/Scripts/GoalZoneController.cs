using UnityEngine;

public class GoalZoneController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Transform targetFace;
    [SerializeField, Min(0.01f)] private float delay = 0.15f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            Invoke(nameof(ChangeFace), delay);
    }

    private void ChangeFace()
    {
        if (targetFace != null && targetFace != gameManager.ActiveFace)
            gameManager.SetFace(targetFace);
    }
}
