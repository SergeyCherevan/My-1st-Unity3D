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

        Debug.Log($"�� ������������. ������: {PhotonNetwork.CloudRegion}");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log($"�� ����������� �� �������!");
    }

    public void CreateRoomButton()
    {
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 2;

        PhotonNetwork.CreateRoom(RoomNameInput.text, options, TypedLobby.Default);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log($"������� �������. Ÿ ���: {PhotonNetwork.CurrentRoom.Name}");
    }

    public override void OnCreateRoomFailed(short returnedCode, string message)
    {
        Debug.Log($"�� ������� ������� �������. ��� ������: {returnedCode}. ���������: {message}");
    }
}
