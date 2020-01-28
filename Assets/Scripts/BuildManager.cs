﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }
    public GameObject buildEffect;

    private TurrentBlueprint turrentToBuild;

    public bool CanBuild => turrentToBuild != null;
    public bool HasMoney => PlayerStats.Money >= turrentToBuild.cost;

    public void SelectTurretToBuild(TurrentBlueprint turret)
    {
        turrentToBuild = turret;
    }

    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < turrentToBuild.cost)
        {
            Debug.Log("Not enouth money!");
            return;
        }

        PlayerStats.Money -= turrentToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turrentToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        GameObject effect = (GameObject)Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect,5f);

        Debug.Log("Turret build!Money left " + PlayerStats.Money);
    }
}
