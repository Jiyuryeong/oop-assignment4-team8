using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    public GameObject scoreboardPanel;
    
    

    public void GameStart()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ExitGame() 
    {
        Application.Quit();
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
