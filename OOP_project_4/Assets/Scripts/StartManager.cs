using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    public GameObject rankRowPrefab;
    public GameObject scoreboardPanel;
    public Transform contentArea;
    
    void Start()
    {
        var ranks = ScoreboardSystem.LoadRankData().data;

        foreach (Transform child in contentArea)
        {
            Destroy(child.gameObject); //새로 돌아갈때마다 없앰
        }

        for (int i = 0; i < ranks.Count; i++) 
        {
            GameObject gameObject = Instantiate(rankRowPrefab, contentArea);
            RankRowUI rowUI = gameObject.GetComponent<RankRowUI>();
            rowUI.setData(i + 1, ranks[i].playerName, ranks[i].score);
        }
    }

    public void GameStart()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ShowScoreBoard()    //스코어보드 보이기
    {
        scoreboardPanel.SetActive(true);
    }

    public void HideScoreBoard()    //스코어보드 숨기기
    {
        scoreboardPanel.SetActive(false);
    }
}
