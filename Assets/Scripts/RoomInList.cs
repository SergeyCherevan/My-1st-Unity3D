using UnityEngine;

using Photon.Pun;
using Photon.Realtime;

using TMPro;

public class RoomInList : MonoBehaviour
{
    public TMP_Text RoomName;
    public TMP_Text PlayerCounter;

    public void SetInfo(RoomInfo room)
    {
        RoomName.text = room.Name;
        PlayerCounter.text = $"{room.PlayerCount}/{room.MaxPlayers}";
    }

    public void JoinToRoom()
    {
        PhotonNetwork.JoinRoom(RoomName.text);
    }
}
