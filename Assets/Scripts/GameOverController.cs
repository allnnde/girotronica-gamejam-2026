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
        currentHpSprite = 3;
        hpImage.sprite = hpSprite[currentHpSprite];
    }

    private void Update()
    {
        
    }

    public void Damage() 
    {
        if (currentHpSprite <= 0) 
        {
            Death();
        }
        else 
        {
            currentHpSprite--;
            hpImage.sprite = hpSprite[currentHpSprite];
        }
    }

    private void Death()
    {
        SceneManager.LoadScene("GameOverScene");
    }
}
