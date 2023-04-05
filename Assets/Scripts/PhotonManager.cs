using UnityEngine;

using Photon.Pun;
using Photon.Realtime;

using TMPro;
using System.Collections.Generic;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    public string region;
    public TMP_InputField RoomNameInput;

    public RoomInList RoomItemPrefab;
    public Transform ContentInScrollView;

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.ConnectToRegion(region);
    }

    public override void OnConnectedToMaster()
    {
        if (!PhotonNetwork.IsConnected)
        {
            return;
        }

        PhotonNetwork.JoinLobby();

        Debug.Log($"Вы подключились");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log($"Вы отключились от сервера!");
    }

    public void CreateRoomButton()
    {
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 2;

        PhotonNetwork.CreateRoom(RoomNameInput.text, options, TypedLobby.Default);
        PhotonNetwork.LoadLevel("Game");
    }

    public override void OnCreatedRoom()
    {
        Debug.Log($"Создана комната. Её имя: {PhotonNetwork.CurrentRoom.Name}");
    }

    public override void OnCreateRoomFailed(short returnedCode, string message)
    {
        Debug.Log($"Не удалось создать комнату. Код ошибки: {returnedCode}. Сообщение: {message}");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomInfos)
    {
        foreach (RoomInfo roomInfo in roomInfos)
        {
            RoomInList room = Instantiate(RoomItemPrefab, ContentInScrollView);

            if (room is not null)
            {
                room.SetInfo(roomInfo);

                Debug.Log($"Комната {roomInfo.Name}. Количество игроков: {room.PlayerCounter.text}");
            }
        }
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");

        Debug.Log($"Подключение игрока к комнате. Её имя: {PhotonNetwork.CurrentRoom.Name}");
    }

    public void JoinRandRoomButton()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public void JoinButton()
    {
        PhotonNetwork.JoinRoom(RoomNameInput.text);
        PhotonNetwork.LoadLevel("Game");
    }

    public void ExitButton()
    {
        PhotonNetwork.LoadLevel("Main");
    }

    public override void OnLeftRoom()
    {
        PhotonNetwork.LoadLevel("Main");

        Debug.Log($"Выход игрока из комнаты. Его имя: {PhotonNetwork.CurrentRoom.Name}");
    }
}
