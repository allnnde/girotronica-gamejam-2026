using UnityEngine;

public class damageZone : MonoBehaviour
{
    [SerializeField]
    private float damageAmount = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Aquí pots afegir el codi per aplicar dany al jugador DamgeMethod(damageAmount);
            Debug.Log("El jugador ha entrat a la zona de dany!");
        }
    }

}
