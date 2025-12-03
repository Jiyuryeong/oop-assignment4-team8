using UnityEngine;
using TMPro;

public abstract class Enemy : MonoBehaviour
{
    public string word;                 // 본인의 단어
    public int typeIndex;               // 몹 종류
    public bool isBullet = false; //총알인지 체크 총알이면 한글자만 출력해요
    public GameObject deathEffectPrefab;

    // 스탯들
    public int maxHp= 1;
    public int score = 1;
    protected int currentHp;
    protected float speed = 1f;
    protected int damage = 1;
    protected bool isDead = false;

    protected TypingInput typingInput;
    protected Transform player;
    protected TMP_Text wordText;
    protected UnityEngine.UI.Image hpFill;

    protected virtual void Awake()
    {
        typingInput = FindFirstObjectByType<TypingInput>();
        player = GameObject.FindWithTag("Player").transform;
        wordText = GetComponentInChildren<TMP_Text>();
        Transform fillTrans = transform.Find("HealthCanvas/Background/CurHp");
        if (fillTrans != null)
        {
            hpFill = fillTrans.GetComponent<UnityEngine.UI.Image>();
        }
    }

    // 생성 시 실행
    public virtual void Spawn()
    {
        isDead = false;
        currentHp = maxHp;
        if (wordText != null)
        {
            wordText.text = word;
        }
        if (hpFill != null)
        {
            hpFill.fillAmount = 1f;
        }
    }

    // 사망 체크
    public bool CheckMatch(string input)
    {
        if (isDead) return false;
        return input == word;
    }
    
    // 체력 감소
    public void TakeDamage(int dmg)
    {
        if (isDead)
        {
            return;
        }

        currentHp -= dmg;
        
        if (currentHp <= 0)
        {
            if (deathEffectPrefab != null)
            {
                Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);
            }

            EnemyManager.Instance.ReturnToPool(this);
            GameManager.Instance.AddScore(score);
            return;
        }
        
        // 피해 받으면 단어 변경
        word = EnemyManager.Instance.wordPool[Random.Range(0, EnemyManager.Instance.wordPool.Length)];
        if (wordText != null)
        {
            wordText.text = word;
        }
        if (hpFill != null)
        {
            hpFill.fillAmount = (float)currentHp / maxHp;
        }
    }

    // 움직임 update
    public virtual void UpdateMovement()  //원래 protected였으나 override를 통해 각 개체마다 이동을 하는 방법이 달라지게 설정
    {
        if (player == null)
        {
            return;
        }

        Vector3 direction = (player.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }
    
    // 플레이어와 충돌 감지
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("충돌감지");
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage(damage);                            // 플레이어에게 데미지
            }
    
            isDead = true;
            EnemyManager.Instance.ReturnToPool(this);           // 사망 → 풀로 반환
        }
    }

    // 사망처리
    public virtual void Dead()
    {
        isDead = true;
        Debug.Log("Enemy Killed: " + word);
    }
}
