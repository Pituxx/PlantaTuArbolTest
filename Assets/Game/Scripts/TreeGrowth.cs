using Photon.Pun;
using System.Collections;
using UnityEngine;

public class TreeGrowth : MonoBehaviourPun
{
    private bool watered = false;
    public float growthTime = 5f;
    public GameObject grownTreePrefab;
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public bool IsWatered()
    {
        return watered;
    }

    public void WaterTree()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            photonView.RPC("RPC_WaterTree", RpcTarget.AllBuffered);
        }
    }

    [PunRPC]
    public void RPC_WaterTree()
    {
        watered = true;
        StartCoroutine(GrowTree());
    }

    private IEnumerator GrowTree()
    {
        yield return new WaitForSeconds(growthTime);
        Grow();
    }

    private void Grow()
    {
        PhotonNetwork.Instantiate(grownTreePrefab.name, transform.position, transform.rotation);
        PhotonNetwork.Destroy(gameObject);
        Debug.Log("El árbol ha crecido.");
        gameManager.CheckVictory();
    }
}
