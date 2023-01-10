using UnityEngine;

public class MuteButton : MonoBehaviour
{

    public void MuteButtonPush()
    {
        FindObjectOfType<SoundManager>().MutePress(); 
    }
}
