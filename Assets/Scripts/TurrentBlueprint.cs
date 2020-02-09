using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]//unity va incarca valorile pentru noi, le vedem in editor
public class TurrentBlueprint
{
    public GameObject prefab;
    public int cost;

    public GameObject upgradedPrefab;
    public int upgradeCost;
}
