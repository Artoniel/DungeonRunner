using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject _tutorialCanvas;

    // Start is called before the first frame update
    void Start()
    {
        DeactivateTutorial();
    }

    public void ActivateTutorial()
    {
        _tutorialCanvas.SetActive(true);
    }
    public void DeactivateTutorial()
    {
        _tutorialCanvas.SetActive(false);
    }
}
