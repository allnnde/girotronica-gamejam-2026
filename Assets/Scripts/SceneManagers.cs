using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagers : MonoBehaviour
{
    public void ReturntoMainGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ReturntoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    //Metode per tornar al ultim nivell arribat

    //Metode per tornar al principi del joc

}