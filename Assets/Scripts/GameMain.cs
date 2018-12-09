using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMain : MonoBehaviourPunCallbacks
{
    IEnumerator LoadScene_co()
    {
        var op = SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);

        while(!op.isDone)
            yield return null;
    }

    #region PUN Callbacks

    public override void OnLeftRoom()
    {
        StartCoroutine(LoadScene_co());
    }

    #endregion
}
