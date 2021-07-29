using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager ins;

    private void Awake()
    {
        if(ins != null)
        {
            return;
        }
        ins = this;
    }

    public GameObject standardTurretPrefab;

    private GameObject turretToBuild;



    void Start()
    {
        turretToBuild = standardTurretPrefab;
    }

    // Update is called once per frame
    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
}
