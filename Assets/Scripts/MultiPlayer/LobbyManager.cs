using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviourPunCallbacks
{

    public void OnCreateNewRoom()
    {
        PhotonNetwork.CreateRoom("MYROOM");
    }

    public void OnJoinExistingRoom()
    {
        PhotonNetwork.JoinRoom("MYROOM");
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Main");
    }

}
