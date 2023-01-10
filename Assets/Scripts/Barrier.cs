using UnityEngine;

public class Barrier : MonoBehaviour
{
    [SerializeField] GameObject _bricksEffect;

private void OnTriggerEnter(Collider other)
{
        if (other.gameObject.CompareTag("Player")) 
        {
            PlayerModifier playerModifier = other.attachedRigidbody.GetComponent<PlayerModifier>();
            if (playerModifier)
            {
                playerModifier.AddHealth(-19);
                Destroy(gameObject);
                Instantiate(_bricksEffect, transform.position, transform.rotation);
            }
        }
            
}
    

}
