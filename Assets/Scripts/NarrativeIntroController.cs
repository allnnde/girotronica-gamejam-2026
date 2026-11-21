using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;

public class NarrativeIntroController : MonoBehaviour
{
    [Tooltip("Opcional. Si se deja vacío, se busca el jugador con la etiqueta Player.")]
    [SerializeField] private MovementController player;
    [SerializeField] private TMP_Text dialogue;
    [SerializeField, Min(1f)] private float charactersPerSecond = 36f;

    private void Awake()
    {
        if (player == null)
            player = GameObject.FindWithTag("Player")?.GetComponent<MovementController>();

        if (player != null)
            player.CanMove = false;

        dialogue.maxVisibleCharacters = 0;
    }

    private IEnumerator Start()
    {
        if (EventSystem.current == null)
            new GameObject("EventSystem", typeof(EventSystem), typeof(InputSystemUIInputModule));

        dialogue.ForceMeshUpdate();
        int length = dialogue.textInfo.characterCount;
        float visible = 0f;
        while (visible < length)
        {
            visible += Time.unscaledDeltaTime * charactersPerSecond;
            dialogue.maxVisibleCharacters = Mathf.Min(length, (int)visible);
            yield return null;
        }
    }

    public void Accept()
    {
        if (player != null)
            player.CanMove = true;

        gameObject.SetActive(false);
    }
}
