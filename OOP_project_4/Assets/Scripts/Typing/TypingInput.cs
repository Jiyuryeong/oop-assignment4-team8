using UnityEngine;
using System;

public class TypingInput : MonoBehaviour
{
    private string playerInput = "";

    public string PlayerInput => playerInput;

    public event Action<string> OnEnter;

    public bool isInputActive = true;

    // 글자 입력 받음
    private void Update()
    {
        //inputactive check
        if (!isInputActive) return;

        string typed = Input.inputString;

        if (!string.IsNullOrEmpty(typed))
        {
            foreach (char c in typed)
            {
                HandleKey(c);
            }
        }
    }

    // 한 글자씩 처리
    private void HandleKey(char c)
    {
        if (c == '\b')
        {
            if (playerInput.Length > 0)
            {
                playerInput = playerInput.Substring(0, playerInput.Length - 1);
            }
            return;
        }

        if (c == '\n' || c == '\r')
        {
            Debug.Log("Entered: " + playerInput);
            
            OnEnter?.Invoke(playerInput);
            
            playerInput = "";
            return;
        }

        if (IsAcceptableChar(c))
        {
            playerInput += c;
        }
    }

    // 문자 입력인지 확인
    private bool IsAcceptableChar(char c)
    {
        return char.IsLetterOrDigit(c);
    }

    // 모든 작성 삭제
    public void ClearInput()
    {
        playerInput = "";
    }
}
