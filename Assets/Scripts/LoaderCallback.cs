using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderCallback : MonoBehaviour
{
    private bool isFirstUpddate = true;

    private void Update()
    {
        if (isFirstUpddate)
        {
            isFirstUpddate = false;
            Loader.LoaderCallback();
        }
    }
}
