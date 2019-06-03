using UnityEngine;

public class Shop : MonoBehaviour {

    BuildManager buildManager;

    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laser;


    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        buildManager.SelectTurretToBuild(standardTurret);
    }
    public void SelectMissileLauncher()
    {
        buildManager.SelectTurretToBuild(missileLauncher);
    }
    public void SelectLaser()
    {
        buildManager.SelectTurretToBuild(laser);
    }
}
