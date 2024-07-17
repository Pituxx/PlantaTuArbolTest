using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantTree : MonoBehaviourPun
{
    public GameObject treePrefab;
    private bool canPlant = false;
    private PlantZone currentPlantZone;

    void Update()
    {
        if (photonView.IsMine)
        {
     
            if (canPlant && Input.GetKeyDown(KeyCode.E))
            {
                photonView.RPC("Plant", RpcTarget.AllBuffered);
            }
        }
    }

    [PunRPC]
    void Plant()
    {
        SeedPickup seedPickup = GetComponent<SeedPickup>();

        if (seedPickup != null && seedPickup.HasSeed() && currentPlantZone != null && !currentPlantZone.HasTree())
        {
            PhotonNetwork.Instantiate(treePrefab.name, currentPlantZone.transform.position, Quaternion.identity);
            seedPickup.UseSeed();
            currentPlantZone.PlantTree();
            Debug.Log("�rbol plantado.");
        }
        else if (currentPlantZone != null && currentPlantZone.HasTree())
        {
            Debug.Log("Ya hay un �rbol plantado en esta zona.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlantZone"))
        {
            currentPlantZone = other.GetComponent<PlantZone>();
            if (currentPlantZone != null && !currentPlantZone.HasTree())
            {
                canPlant = true;
                Debug.Log("Puedes plantar un �rbol aqu�.");
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PlantZone"))
        {
            canPlant = false;
            currentPlantZone = null;
            Debug.Log("Has salido de la zona de plantaci�n.");
        }
    }
}
