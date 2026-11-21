using UnityEngine;

public class damageZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<GameOverController>().Damage();
            Debug.Log("El jugador ha entrat a la zona de dany!");
        }
    }

    //En caso de pit combinar el codigo de daño con el de tp al checkpoint de la cara del plano.

}
