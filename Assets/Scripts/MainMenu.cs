using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public string levelToLoad = "Level01";
    public int index = 1;

    public void Play()
    {
        
        SceneManager.LoadScene(levelToLoad);
    }

    public void Quit()
    {
        Application.Quit();
    }
	
}
