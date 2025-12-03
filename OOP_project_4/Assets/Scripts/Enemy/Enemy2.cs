using UnityEngine;

public class Enemy2 : Enemy //»ç°¢Çü
{
    void Start()
    {
        typeIndex = 1;
        maxHp= 3;
        speed = 0.3f;
        damage = 10;
        score = 50;
    }

    void Update()
    {
        UpdateMovement();
    }
}
