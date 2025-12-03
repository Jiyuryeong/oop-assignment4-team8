using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;                 // 싱글톤

    [SerializeField] private TextMeshProUGUI scoreText;

    private int score = 0;

    public TypingInput typingInput;

    [Header("Game Over UI Components")]
    public GameObject gameOverPanel;
    public GameObject nameInput;
    public GameObject confirmButton;
    public TMP_InputField nameInputField;
    public GameObject retryButton;
    public GameObject mainButton;
    public TextMeshProUGUI finalScoreText;



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateScoreUI();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Score : {score}";
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void OnGameOver()
    {
        Time.timeScale = 0f; //게임 멈추기
        gameOverPanel.SetActive(true); 
        finalScoreText.text = $"Score : {score}";
        if (typingInput != null)
        {
            typingInput.isInputActive = false;
            typingInput.ClearInput();
        }
        nameInput.SetActive(true); //입력창, 등록버튼 띄우기

    }

    public void SubmitScore()
    {
        string playerName = nameInputField.text;
        if (string.IsNullOrWhiteSpace(playerName))  //입력값이 없으면 unknown으로 저장
            playerName = "Unknown";
        ScoreboardSystem.SaveScore(playerName, score);

        //입력창 숨기고
        nameInput.gameObject.SetActive(false);
        //버튼 두개 활성화
        mainButton.SetActive(true);
        retryButton.SetActive(true);

    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartScene");  //시작씬으로 이동
    }
    public void RetryGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameScene");  //씬 다시 불러와서 초기화 
    }

   
}
