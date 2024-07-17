using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTree : MonoBehaviourPun
{
    private bool canWater = false;
    private TreeGrowth currentTree;

    void Update()
    {
        if (photonView.IsMine)
        {
            

            if (canWater && Input.GetKeyDown(KeyCode.E))
            {
                WaterPickup waterPickup = GetComponent<WaterPickup>();

                if (waterPickup != null && waterPickup.HasWater() && currentTree != null && !currentTree.IsWatered())
                {
                    photonView.RPC("WaterTrees", RpcTarget.AllBuffered);
                }
            }
        }
    }

    [PunRPC]
    void WaterTrees()
    {
        WaterPickup waterPickup = GetComponent<WaterPickup>();
        waterPickup.UseWater();
        currentTree.WaterTree();
        Debug.Log("Árbol regado.");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Tree"))
        {
            currentTree = other.GetComponent<TreeGrowth>();
            if (currentTree != null && !currentTree.IsWatered())
            {
                canWater = true;
                Debug.Log("Puedes regar este árbol.");
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Tree"))
        {
            canWater = false;
            currentTree = null;
            Debug.Log("Has salido de la zona del árbol.");
        }
    }
}
