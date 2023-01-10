using TMPro;
using UnityEngine;

public class LanguageButton : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;
    public void ChangeLanguage(string lang)
    {
        Language.Instance.CurrentLanguage = lang;
        if (lang == "en")
        {
            _text.GetComponent<InternationalText>().ForceChangeEnglish();
        }
        else if (lang == "ru")
        {
            _text.GetComponent<InternationalText>().ForceChangeRussian();  
        }
        else if (lang == "tr")
        {
            _text.GetComponent<InternationalText>().ForceChangeTurkish();
        }
        else
        {
            _text.GetComponent<InternationalText>().ForceChangeEnglish();
        }
    }
}
