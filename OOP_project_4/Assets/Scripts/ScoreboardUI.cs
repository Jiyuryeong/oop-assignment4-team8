using UnityEngine;

public class ScoreboardUIManager : MonoBehaviour
{

    public Transform contentArea;
    public GameObject rankRowPrefab;
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

   
}
