using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class GameManager : MonoBehaviour
{

    public Transform SpawnPoint;

    void Start()
    {
        if (PhotonNetwork.InRoom)
        {
            PhotonNetwork.Instantiate("Player", SpawnPoint.position, SpawnPoint.rotation);
        }
    }

}
