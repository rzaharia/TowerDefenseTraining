using System;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurrentBlueprint standardTurret;
    public TurrentBlueprint missleLauncher;
    public TurrentBlueprint laserBeamer;


    private BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        //Debug.Log("Standard turret selected");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissleLauncher()
    {
        buildManager.SelectTurretToBuild(missleLauncher);
    }

    public void SelectLaserBeamer()
    {
        buildManager.SelectTurretToBuild(laserBeamer);
    }
}
