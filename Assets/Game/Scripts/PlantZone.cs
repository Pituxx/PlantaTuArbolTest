using Photon.Pun.Demo.PunBasics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantZone : MonoBehaviour
{
    private bool hasTree = false;
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public bool HasTree()
    {
        return hasTree;
    }

    public void PlantTree()
    {
        hasTree = true;
        gameManager.CheckVictory();
    }
}

