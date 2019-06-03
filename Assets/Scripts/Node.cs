using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    public Color hoverColor;
    private Color startColor;
    private Renderer rend;
    public Vector3 positionOffset;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool hasUpgraded = false;
    

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.money < blueprint.cost)
        {
            return;
        }
        PlayerStats.money -= blueprint.cost;

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBlueprint = blueprint;
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.money < turretBlueprint.upgradeCost)
        {
            return;
        }

        Destroy(turret);

        PlayerStats.money -= turretBlueprint.upgradeCost;

        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        hasUpgraded = true;

    }

    public void SellTurret()
    {
        
        PlayerStats.money += turretBlueprint.GetSellAmount();

        Destroy(turret);
        turretBlueprint = null;

    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }else
        {
            rend.material.color = Color.red;
        }

        
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if(turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild)
            return;

        BuildTurret(buildManager.GetTurretToBuild());
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
