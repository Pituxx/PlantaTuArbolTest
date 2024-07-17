using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviourPunCallbacks
{
    private PlantZone[] plantZones;
    private TreeGrowth[] trees;
    public GameObject canvas;

    void Start()
    {
        plantZones = FindObjectsOfType<PlantZone>();
        trees = FindObjectsOfType<TreeGrowth>();
    }

    public void CheckVictory()
    {
        foreach (PlantZone zone in plantZones)
        {
            if (!zone.HasTree())
            {
                return; 
            }
        }

        foreach (TreeGrowth tree in trees)
        {
            if (!tree.IsWatered())
            {
                return; 
            }
        }

        Victory();
    }

    private void Victory()
    {
        Debug.Log("¡Victoria! Todos los árboles han sido plantados y han crecido.");
        // logic
        canvas.SetActive(true);
    }
}
