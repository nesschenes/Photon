using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class Launcher : MonoBehaviourPunCallbacks
{
    public static Launcher Instance { get; private set; }

    void Awake()
    {
        Instance = this;

        // master client will sync all clients to load level.
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void Connect(string _playerName)
    {
        if (PhotonNetwork.IsConnected)
        {
            Debug.Log("Already Connected!");
            return;
        }

        PhotonNetwork.NickName = _playerName;
        PhotonNetwork.ConnectUsingSettings();
    }

    #region PUN Callbacks

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connect.. Successful!");

        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogFormat("Disconnect.. Reason : {0}", cause);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Join Room.. Successful!");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.LogFormat("Join Room.. Faild! OperationCode : {0}, Reason : {0}", message);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.LogFormat("Join Random Room.. Faild! OperationCode : {0}, Reason : {0}", message);

        PhotonNetwork.CreateRoom(null, new RoomOptions());
    }

    #endregion
}
