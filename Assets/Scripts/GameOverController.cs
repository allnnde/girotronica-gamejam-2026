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
        hpImage.sprite = hpSprite[currentHpSprite-1];
    }

    private void Update()
    {
        
    }

    public void Damage() 
    {
        currentHpSprite--;
        if (currentHpSprite <= 0) 
        {
            Death();
        }
        else 
        {
            hpImage.sprite = hpSprite[currentHpSprite-1];
        }
    }

    private void Death()
    {
        SceneManager.LoadScene("GameOverScene");
    }
}
