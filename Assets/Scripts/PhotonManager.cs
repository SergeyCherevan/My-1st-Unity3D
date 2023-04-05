using UnityEngine;

using Photon.Pun;
using Photon.Realtime;

using TMPro;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    public string region;
    public TMP_InputField RoomNameInput;

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

        Debug.Log($"Вы подключились. Регион: {PhotonNetwork.CloudRegion}");
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
    }

    public override void OnCreatedRoom()
    {
        Debug.Log($"Создана комната. Её имя: {PhotonNetwork.CurrentRoom.Name}");
    }

    public override void OnCreateRoomFailed(short returnedCode, string message)
    {
        Debug.Log($"Не удалось создать комнату. Код ошибки: {returnedCode}. Сообщение: {message}");
    }
}
