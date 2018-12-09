using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class ConnectionPanel : MonoBehaviourPunCallbacks
{
    [SerializeField]
    InputField m_PlayerNameField = null;
    [SerializeField]
    Button m_ConnectBtn = null;
    [SerializeField]
    Text m_ConnectionStateLabel = null;

    const string CONNECTED_MESSAGE = "{0} is Connected..";
    const string DISCONNECTED_MESSAGE = "{0} is Disconnected.. Reason : {1}";
    const string JOIN_ROOM_SUCCESSFUL_MESSAGE = "{0} try to join Room.. Successful!";
    const string JOIN_ROOM_FAILED_MESSAGE = "{0} try to join Room.. Failed! Reason : {1}";
    const string JOIN_RANDOM_ROOM_FAILED_MESSAGE = "{0} try to join random Room.. Failed! Reason : {1}";

    string mPlayerName = "";

    void Awake()
    {
        m_PlayerNameField.onValueChanged.AddListener(OnPlayerNameChanged);
        m_ConnectBtn.onClick.AddListener(OnConnect);
    }

    void OnDestroy()
    {
        m_PlayerNameField.onValueChanged.RemoveListener(OnPlayerNameChanged);
        m_ConnectBtn.onClick.RemoveListener(OnConnect);
    }

    void OnPlayerNameChanged(string _content)
    {
        mPlayerName = _content;
    }

    void OnConnect()
    {
        Launcher.Instance.Connect(mPlayerName);
    }

    #region PUN Callbacks

    public override void OnConnectedToMaster()
    {
        m_ConnectionStateLabel.text = string.Format(CONNECTED_MESSAGE, mPlayerName);
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        m_ConnectionStateLabel.text = string.Format(DISCONNECTED_MESSAGE, mPlayerName, cause);
    }

    public override void OnJoinedRoom()
    {
        m_ConnectionStateLabel.text = string.Format(JOIN_ROOM_SUCCESSFUL_MESSAGE, mPlayerName);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        m_ConnectionStateLabel.text = string.Format(JOIN_ROOM_FAILED_MESSAGE, mPlayerName, message);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        m_ConnectionStateLabel.text = string.Format(JOIN_RANDOM_ROOM_FAILED_MESSAGE, mPlayerName, message);
    }

    #endregion
}
