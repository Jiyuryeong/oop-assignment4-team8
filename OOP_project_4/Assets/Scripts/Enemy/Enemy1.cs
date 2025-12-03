using UnityEngine;

public class Enemy1 : Enemy //¿ø
{
    void Start()
    {
        typeIndex = 0;
        maxHp= 1;
        speed = 0.7f;
        damage = 10;
        score = 10;
    }

    void Update()
    {
        UpdateMovement();
    }
}
