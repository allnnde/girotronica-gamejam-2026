using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagers : MonoBehaviour
{
    public void ReturntoMainGame()
    {
        Debug.Log("Tornant al joc principal...");
        SceneManager.LoadScene("Game_Test");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ReturntoMainMenu()
    {
        Debug.Log("Tornant al joc principal...");
        SceneManager.LoadScene("MainMenu");
    }

    //Metode per tornar al ultim nivell arribat

    //Metode per tornar al principi del joc

}