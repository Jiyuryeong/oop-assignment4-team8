using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Image hpFill;
    
    [SerializeField] private int maxHp = 50;
    
    public int currentHp = 0;

    private void Start()
    {
        currentHp = maxHp;
        hpFill.fillAmount = 1f;
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        if (currentHp < 0)
        {
            currentHp = 0;
        }

        hpFill.fillAmount = (float)currentHp / maxHp;

        if (currentHp == 0)
        {
            Debug.Log("Player Dead!");
            // 사망처리
            GameManager.Instance.OnGameOver(); //gameover 넘어감
        }
    }
}
