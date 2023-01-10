using UnityEngine;

public class ActivationTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _encounterLeft;
    [SerializeField] private GameObject _encounterRight;
    [SerializeField] private GameObject _barrier;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Activation();
        }
    }


    private void Activation()
    {
        _barrier.SetActive(true);
        _encounterLeft.SetActive(true);
        _encounterRight.SetActive(true);
    }
}
