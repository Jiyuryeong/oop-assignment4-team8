using System.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy4 : Enemy
{   
    public GameObject bulletPrefab;
    public float fireRate = 5.0f; //발사주기
    public override void Spawn()
    {
        base.Spawn();
        StartCoroutine(FireCycle());  //coroutine으로 총알 발사 주기 조절

    }

    IEnumerator FireCycle()
    {
        yield return new WaitForSeconds(8.0f);  //처음 딜레이

        while (!isDead)
        {
            Shoot();
            yield return new WaitForSeconds(fireRate);
        }
        
    }

    void Shoot() //총알 발싸!!!히히히히
    {
        if (bulletPrefab != null || isDead)
            return;
        Enemy spawnedEnemy = EnemyManager.Instance.SpawnEnemy(4);

        EnemyBullet bullet = spawnedEnemy as EnemyBullet;

        if(bullet != null)
        {
            bullet.Launch(transform.position);  
        }
    }

    

    private void OnDisable()
    {
        StopAllCoroutines();
    }
    // 육각형
    void Start()
    {
        typeIndex = 3;
        maxHp = 2;
        speed = 0.3f;
        damage = 10;
        score = 100;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
    }
}
