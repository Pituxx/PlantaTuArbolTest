using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject[] playerPrefabs;   
    public Transform[] spawnPoints;      

    private void Start()
    {
        int playerAvatarIndex = (int)PhotonNetwork.LocalPlayer.CustomProperties["playerAvatar"];

        Transform spawnPoint = spawnPoints[playerAvatarIndex];

        GameObject playerToSpawn = playerPrefabs[playerAvatarIndex];
        PhotonNetwork.Instantiate(playerToSpawn.name, spawnPoint.position, spawnPoint.rotation);
    }
}
