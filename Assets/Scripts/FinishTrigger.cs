using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerBehaviour playerBehaviour = other.attachedRigidbody.GetComponent<PlayerBehaviour>();
            if (playerBehaviour)
            {
                playerBehaviour.StartFinishBehavior();
                FindObjectOfType<GameManager>().ShowFinishWindow();
            }
        }
    }
}
