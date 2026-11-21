using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    [SerializeField]
    private Sprite[] hpSprite;

    [SerializeField]
    private Image hpImage;

    [SerializeField]
    private int currentHpSprite = 3;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void Damage() 
    {
        currentHpSprite--;
        hpSprite[currentHpSprite];
        if (currentHpSprite < 0) 
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
