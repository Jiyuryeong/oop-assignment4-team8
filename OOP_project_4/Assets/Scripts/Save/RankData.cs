    
//data 저장 클래스

[System.Serializable]
public class RankData
{
    public string playerName;
    public int score;

    public RankData(string name, int score)
    {
        this.playerName = name;
        this.score = score;
    }
    
}

[System.Serializable]
public class RankDataList
{
    public System.Collections.Generic.List<RankData> data = new System.Collections.Generic.List<RankData>();
}
