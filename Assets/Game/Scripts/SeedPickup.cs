using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedPickup : MonoBehaviourPun
{
    private bool canPickup = false;
    private bool hasSeed = false;

    public bool HasSeed()
    {
        return hasSeed;
    }

    public void UseSeed()
    {
        hasSeed = false;
    }

    void Update()
    {
        if (photonView.IsMine)
        {

            if (canPickup && Input.GetKeyDown(KeyCode.E))
            {

                photonView.RPC("SeedPick", RpcTarget.AllBuffered);
            }
        }
    }

    [PunRPC]
    void SeedPick()
    {
        hasSeed = true;
        Debug.Log("Semilla recogida.");
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SeedBox"))
        {
            canPickup = true;
            Debug.Log("Puedes recoger una semilla.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("SeedBox"))
        {
            canPickup = false;
            Debug.Log("Has salido de la zona de recogida de semillas.");
        }
    }
}
