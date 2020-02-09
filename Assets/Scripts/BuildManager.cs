using System;
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
    public Node selectedNode;
    public NodeUI nodeUI;

    private TurrentBlueprint turrentToBuild;

    public bool CanBuild => turrentToBuild != null;
    public bool HasMoney => PlayerStats.Money >= turrentToBuild.cost;
    
    public void SelectNode(Node node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }
        
        selectedNode = node;
        turrentToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public void SelectTurretToBuild(TurrentBlueprint turret)
    {
        turrentToBuild = turret;
        DeselectNode();
    }

    public TurrentBlueprint GetTurretToBuild()
    {
        return turrentToBuild;
    }
}
