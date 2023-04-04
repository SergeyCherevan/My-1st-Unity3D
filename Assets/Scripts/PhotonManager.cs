using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    string region;
    
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.ConnectToRegion(region);
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log($"Вы подключились: {PhotonNetwork.CloudRegion}");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log($"Вы отключились от сервера!");
    }
}
