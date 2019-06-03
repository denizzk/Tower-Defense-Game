using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelWon : MonoBehaviour {

    public string nextLevel = "Level02";
    public int LevelToUnlock = 2;


    public void Continue()
    {
      
        PlayerPrefs.SetInt("levelreached", LevelToUnlock);
        SceneManager.LoadScene(nextLevel);
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
