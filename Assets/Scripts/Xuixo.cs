using UnityEngine;
using UnityEngine.SceneManagement;

public class Xuixo : MonoBehaviour
{


    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Has guanyat!");
            SceneManager.LoadScene("VictoryScene");
        }
    }


}
