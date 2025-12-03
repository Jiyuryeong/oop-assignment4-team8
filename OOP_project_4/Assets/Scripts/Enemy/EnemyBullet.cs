using UnityEngine;

public class EnemyBullet : Enemy
{
    private Vector2 fixedDirection;

    protected override void Awake()
    {
        base.Awake();
        isBullet = true; 
    }

    public void Launch(Vector2 startPosition)
    {
        transform.position = startPosition;   //위치 수정
        Vector3 direction = (player.position - transform.position).normalized;
    }


    void Start()
    {
        typeIndex = 4;
        maxHp = 1;
        speed = 4.0f;
        damage = 3;
        score = 1;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
    }
}
