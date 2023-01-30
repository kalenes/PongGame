using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LobbyManager : MonoBehaviourPunCallbacks
{
    public TMPro.TMP_InputField roomInputField;
    public GameObject lobbyPanel;
    public GameObject roomPanel;
    public Text roomName;

    public RoomItem roomItemPrefab;
    List<RoomItem> roomItemsList = new List<RoomItem>();
    public Transform contentObject;

    public float timeBetweenUpdater = 1.5f;
    float nextUpdateTime;
    private void Start()
    {
        PhotonNetwork.JoinLobby();
    }
    private void Update()
    {
        /*if(PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            SceneManager.LoadScene("SampleScene");
        }*/
    }
    public void OnClickCreate()
    {
        if (roomInputField.text.Length >=1)
        {
            PhotonNetwork.CreateRoom(roomInputField.text,new RoomOptions(){MaxPlayers=2});
        }
    }
    public override void OnJoinedRoom()
    {
        lobbyPanel.SetActive(false);
        roomPanel.SetActive(true);
        roomName.text = "Room Name: " + PhotonNetwork.CurrentRoom.Name;
        SceneManager.LoadScene("SampleScene");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        if(Time.time >= nextUpdateTime)
        {
            UpdateRoomList(roomList);
            nextUpdateTime = Time.time + timeBetweenUpdater;
        }
        
    }

    void UpdateRoomList(List<RoomInfo> list)
    {
        foreach (RoomItem item in roomItemsList)
        {
            Destroy(item.gameObject);
        }
        roomItemsList.Clear();

        foreach (RoomInfo room in list)
        {
            RoomItem newRoom = Instantiate(roomItemPrefab, contentObject);
            newRoom.SetRoomName(room.Name);
            roomItemsList.Add(newRoom);
        }
    }
    public void JoinRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName); 
    }
    public void OnClickLeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }
    public override void OnLeftRoom()
    {
        roomPanel.SetActive(false);
        lobbyPanel.SetActive(true);
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

}
