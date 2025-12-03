using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy3 : Enemy //삼각형
{
    public override void UpdateMovement()  //override 이용해서 도는 기능을 추가
    {
        base.UpdateMovement();
        transform.Rotate(0,0,260*Time.deltaTime);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        typeIndex = 2;
        maxHp = 1;
        speed = 1.7f;
        damage = 10;
        score = 20;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
    }
}
