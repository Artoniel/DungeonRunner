using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField] private GameObject _swordInHand;
    [SerializeField] private GameObject _swordOnBack;
    [SerializeField] private GameObject _hitParticle;
    [SerializeField] private GameObject _healParticle;
    [SerializeField] private GameObject _deathParticle;
    [SerializeField] private PlayerBehaviour _playerBehaviour;
    [SerializeField] private Transform _hitPoint;
    [SerializeField] private AudioSource _hitSound;
    [SerializeField] private AudioSource _healSound;

    private void Start()
    {
        transform.Rotate(0, 0, 0);
        _swordOnBack.SetActive(false);
        _swordInHand.SetActive(true);   
    }
    public void Hit()
    {

        Instantiate(_hitParticle, _hitPoint);
        _hitSound.Play();
        _playerBehaviour.KillEnemy();
    }
    public void Dance()
    {
        _swordOnBack.SetActive(true);
        _swordInHand.SetActive(false);
        transform.Rotate(0,180,0);
    }
    public void Healing()
    {
        _healSound.Play();
        Instantiate(_healParticle, transform);
    }
    public void Death()
    {
        _hitSound.Play();
        GameObject grave = Instantiate(_deathParticle, transform);
        if (grave.transform.parent != null)
        {
            grave.transform.parent = null;
        }
    }
}
