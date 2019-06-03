using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour {

    public Text lives;

	void Update () {

        lives.text = "Lives : " + PlayerStats.lives.ToString();

        if (PlayerStats.lives <= 1)
        {
            lives.color = Color.red;
        }else
        {
            lives.color = Color.white;
        }

        
	
	}
}
