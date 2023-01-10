using UnityEngine;

public class PreFinishTrigger : MonoBehaviour
{
private void OnTriggerEnter(Collider other) 
{
        if (other.gameObject.CompareTag("Player")) 
        {
            PlayerBehaviour playerBehaviour = other.attachedRigidbody.GetComponent<PlayerBehaviour>();
            if (playerBehaviour)
            {
                playerBehaviour.StartPreFinishBehavior();
            }
        }
    
}
}
