using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private GameObject turret;

    private Renderer renderer;

    private Color starColor;

    public Color hoverColor;

    public Vector3 positionOffset;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        starColor = renderer.material.color;
    }

    private void OnMouseEnter()
    {
        renderer.material.color = hoverColor;

    }

    private void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("Can't not build here!");
        }

        GameObject turretToBuild = BuildManager.ins.GetTurretToBuild();
        turret = Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }

    private void OnMouseExit()
    {
        renderer.material.color = starColor;
    }
}
