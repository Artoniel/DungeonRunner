using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private PreFinishBehaviour _preFinishBehaviour;
    [SerializeField] private AnimationManager _playerAnimationManager;

    [SerializeField] private Animator _animator;

    private GameObject _currentTarget;
    // Start is called before the first frame update
    void Start()
    {
        _playerController.enabled = false;
        _preFinishBehaviour.enabled = false;
    }

    public void Play()
    {
        _playerController.enabled = true;
    }
    public void StartPreFinishBehavior()
    {
        _playerController.enabled = false;
        _preFinishBehaviour.enabled = true;
        _animator.SetBool("Run_b", true);
    }
    public void StartFinishBehavior()
    {
        _playerController.enabled = false;
        _preFinishBehaviour.enabled = false;
        
        _animator.SetBool("Run_b", false);
        _animator.SetTrigger("Dance_t");
        _playerAnimationManager.Dance();
    }

    public void StartFightingBehavior(GameObject target) 
    {
        _animator.SetTrigger("Attack_t");
        _currentTarget= target;
    }

    public void StartHealingBehavior()
    {
        _playerAnimationManager.Healing();
        Debug.Log("Healing!");
    }

    public void KillEnemy()
    {
        //
        //Destroy(_currentTarget);
        _currentTarget.SetActive(false);
    }
}
