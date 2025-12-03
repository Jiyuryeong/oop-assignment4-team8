using UnityEngine;
using System.Collections.Generic;

public static class ScoreboardSystem
{
    private const string SaveKey = "Scoreboard_Json";

    public static void SaveScore(string name, int score)  //점수 저장 시스템
    {
        //data 불러오기
        RankDataList rankList = LoadRankData(); 
        //data 추가
        rankList.data.Add(new RankData(name, score));
        //점수순 정렬
        rankList.data.Sort((a,b)=>b.score.CompareTo(a.score)); 
        
        //저장하기
        string json = JsonUtility.ToJson(rankList);
        PlayerPrefs.SetString(SaveKey, json);
        PlayerPrefs.Save();
    }

    public static RankDataList LoadRankData()   //data 불러오기
    {
        if (PlayerPrefs.HasKey(SaveKey))    //있는대로싹다불러오기
        {
            string json = PlayerPrefs.GetString(SaveKey);
            return JsonUtility.FromJson<RankDataList>(json);
        }
        return new RankDataList();
    }
    public static void Clear() //그냥만듬
    {
        PlayerPrefs.DeleteKey(SaveKey);
    }
}
