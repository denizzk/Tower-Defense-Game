using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour {

    public static bool hasEnded;
    public GameObject gameOverUI;
    public GameObject levelWonUI;

    


    void Start()
    {
        hasEnded = false;
    }

	void Update () {

        if (hasEnded)
            return;

        if(PlayerStats.lives <= 0)
        {
            EndGame();
        }
	
	}

    void EndGame()
    {
        hasEnded = true;
        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        hasEnded = true;
        levelWonUI.SetActive(true);
        
    }
}
