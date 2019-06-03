using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour {

    public Text money;
    public Color moneyColor;

	void Update () {

        money.text = "$" + PlayerStats.money.ToString();

        if(money.text == "$0")
        {
            money.color = Color.red;
        }else
        {
            money.color = moneyColor;
        }

	}
}
