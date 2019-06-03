using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour {

    public GameObject ui;
    public Text rounds;

	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space))
        {
            Toggle();
        }

	}

    public void Toggle()
    {
        rounds.text = PlayerStats.rounds.ToString();

        ui.SetActive(!ui.activeSelf);

        if (ui.activeSelf)
        {
            Time.timeScale = 0f;
        }else
        {
            Time.timeScale = 1f;
        }
    }

    public void Retry()
    {
        Toggle();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        Toggle();
        SceneManager.LoadScene("Menu");
    }
}
