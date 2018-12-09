using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : MonoBehaviour
{
    [SerializeField]
    Button m_LeaveBtn = null;

    void Awake()
    {
        m_LeaveBtn.onClick.AddListener(OnLeave);
    }

    void OnDestroy()
    {
        m_LeaveBtn.onClick.RemoveListener(OnLeave);
    }

    void OnLeave()
    {
        PhotonNetwork.LeaveRoom();
    }
}
