using UnityEngine;
using Photon.Pun;
using TMPro;

public class UIManager : MonoBehaviourPun
{
    //public TextMeshProUGUI scoreText;
    //private int score = 0;

    //void Start()
    //{
    //    UpdateScoreText();
    //}

    //[PunRPC]
    //public void UpdateScore(int newScore)
    //{
    //    score = newScore;
    //    UpdateScoreText();
    //}

    //void UpdateScoreText()
    //{
    //    scoreText.text = "Árboles plantados: " + score;
    //}

    //public void AddScore(int amount)
    //{
    //    if (photonView.IsMine)
    //    {
    //        score += amount;
    //        photonView.RPC("UpdateScore", RpcTarget.All, score);
    //    }
    //}
}
