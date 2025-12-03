using TMPro;
using UnityEngine;

public class TypingUI : MonoBehaviour
{
    [SerializeField] private TMP_Text inputText;
    [SerializeField] private TypingInput typingInput;

    private void Update()
    {
        inputText.text = typingInput.PlayerInput;
    }
}
