using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour {

    private Node target;
    public GameObject ui;
    public Text upgradeCost;
    public Text sellCost;

    public Button upgradeButton;
    

    public void SetTarget(Node _target)
    {

        
        target = _target;
        transform.position = target.GetBuildPosition();

        ui.SetActive(true);

        if(target.hasUpgraded)
        {
            upgradeCost.text = "DONE";
            upgradeButton.enabled = false;
            
        }
        else
        {
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
            upgradeButton.enabled = true;
          

        }

        sellCost.text = "$" + target.turretBlueprint.GetSellAmount();

    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        Hide();
        //BuildManager.instance.DeselectNode();

    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }

}
