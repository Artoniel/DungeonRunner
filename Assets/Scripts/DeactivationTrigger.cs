using UnityEngine;

public class DeactivationTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _encounterLeft;
    [SerializeField] private GameObject _encounterRight;
    [SerializeField] private GameObject _barrier;
    [SerializeField] private GameObject _coinPocket;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Deactivation();
        }
    }


    private void Deactivation()
    {
        _barrier.SetActive(false);
        _encounterLeft.SetActive(false);
        _encounterRight.SetActive(false);
        _coinPocket.SetActive(false);
    }
}
