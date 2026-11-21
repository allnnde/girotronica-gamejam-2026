using UnityEngine;

public class damageZone : MonoBehaviour
{
    [SerializeField]
    private float damageAmount = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<GameOverController>().Damage();
            Debug.Log("El jugador ha entrat a la zona de dany!");
        }
    }

}
