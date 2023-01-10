using System.Collections;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Yandex : MonoBehaviour
{

    [DllImport("__Internal")]
    private static extern void RateGame();



    public void RateGameButton()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        RateGame();
#endif
    }


}
