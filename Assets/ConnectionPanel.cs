using UnityEngine;
using UnityEngine.UI;

public class ConnectionPanel : MonoBehaviour
{
    [SerializeField]
    InputField m_PlayerNameInf = null;
    [SerializeField]
    Button m_ConnectBtn = null;

    string mPlayerName = "";

    void Awake()
    {
        m_PlayerNameInf.onValueChanged.AddListener(OnPlayerNameChanged);
        m_ConnectBtn.onClick.AddListener(OnConnect);
    }

    void OnDestroy()
    {
        m_PlayerNameInf.onValueChanged.RemoveListener(OnPlayerNameChanged);
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
}
