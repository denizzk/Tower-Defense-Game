using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour {

    public Button[] levelButtons;
    

    public void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelreached", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if(i + 1 > levelReached)
            levelButtons[i].interactable = false;
        }
    }

	public void Select(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
