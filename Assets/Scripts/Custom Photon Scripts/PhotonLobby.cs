using Photon.Realtime;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonLobby : MonoBehaviourPunCallbacks
{
    public static PhotonLobby lobby;
    public GameObject battleButton;
    public GameObject cancelButton;

    private void Awake()
    {
        lobby = this; //Creates singleton lobby
    }
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public void OnJoinButtonClicked()
    {
        battleButton.SetActive(false);
        cancelButton.SetActive(true);
        PhotonNetwork.JoinRandomRoom();
    }

    public void OnCancelButtonClicked()
    {
        cancelButton.SetActive(false);
        battleButton.SetActive(true);
        PhotonNetwork.LeaveRoom();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Player has connected to the Photon Master Server");
        PhotonNetwork.AutomaticallySyncScene = true;
        RoomOptions roomOptions = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 20 };
        PhotonNetwork.JoinOrCreateRoom("Dingus", roomOptions, null);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Tried to join random game but failed. There must be no open games availalbe");
        CreateRoom();
    }

    void CreateRoom()
    {
        int randomRoomName = Random.Range(0, 10000);
        RoomOptions roomOptions = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 20 };
        PhotonNetwork.CreateRoom("Room" + randomRoomName, roomOptions, null);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Tried to create a new room but failed");
        CreateRoom();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
