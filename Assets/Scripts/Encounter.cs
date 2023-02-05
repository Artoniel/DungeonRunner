using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encounter : MonoBehaviour
{
    [SerializeField] private int _value;
    [SerializeField] private EncounterTooltip _encounterTooltip;

    private void OnValidate()
    {
        _encounterTooltip.UpdateVisual(_value);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerModifier playerModifier = other.attachedRigidbody.GetComponent<PlayerModifier>();
            PlayerBehaviour playerBehaviour = other.attachedRigidbody.GetComponent<PlayerBehaviour>();
            if (playerModifier)
            {
                playerModifier.AddHealth(_value);
            }
            if (_value < 0) 
            {
                _encounterTooltip.AttackAnimation();
                
                if (playerBehaviour)
                {                    
                    if (playerModifier.CheckHealth())
                    {
                        Debug.Log("Add Score "+ Mathf.Abs(_value).ToString());
                        FindObjectOfType<ScoreManager>().IncreaseScore(Mathf.Abs(_value));
                    }
                    playerBehaviour.StartFightingBehavior(this.gameObject);
                }
            }
            else
            {
                
                if (playerBehaviour)
                {
                    playerBehaviour.StartHealingBehavior();
                    //Destroy(gameObject);
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
