using UnityEngine;
using UnityEngine.SceneManagement;

public class Xuixo : MonoBehaviour
{


    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Has guanyat!");
            other.gameObject.GetComponent<MovementController>().enabled = false;
            Invoke("GoToVictroyScene", 2f);
        }
    }

    private void GoToVictroyScene()
    {
        SceneManager.LoadScene("VictoryScene");
    }

}
