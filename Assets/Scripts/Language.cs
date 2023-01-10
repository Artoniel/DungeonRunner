using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class Language : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern string GetLang();


    public string CurrentLanguage; // ru en

    public static Language Instance;

    private void Awake()
    {
        if (Instance == null) 
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
#if UNITY_WEBGL && !UNITY_EDITOR
            CurrentLanguage = GetLang();
#endif
        }
        else
        {
            Destroy(gameObject);
        }

    }
        
}
