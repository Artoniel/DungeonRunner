using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerModifier : MonoBehaviour
{
    
    [SerializeField] private int _health;
    [SerializeField] private int _maxHealth;
    [SerializeField] private Slider _healthBar;

    [SerializeField] private int _lives;

    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private TextMeshProUGUI _livesText;
    [SerializeField] private TextMeshProUGUI _livesText2;

    
    [SerializeField] AudioSource _growthSound;
    [SerializeField] AudioSource _widthSound;

    private void Start()
    {
        if (_healthBar == null)
        {
            _healthBar = FindObjectOfType<Slider>();
        }
        SetMaxHealth(Progress.Instance.PlayerInfo.MaxHealth);
        UpdateHealth();
        SetLives(Progress.Instance.PlayerInfo.Lives);
    }

    public void SetMaxHealth(int value)
    {
        _maxHealth = value;
        if (value > 0)
        {
            _widthSound.Play();
            _health = _maxHealth;
        }
    }

    public void SetLives(int value)
    {
        _lives = value;
        if (value > 0)
        {
            _widthSound.Play();
        }
        _livesText.text = _lives.ToString();
        _livesText2.text = _livesText.text;
    }


    public void AddHealth(int value)
    {
        _health += value;
        _health = Mathf.Clamp(_health, 0, _maxHealth);
        UpdateHealth();
        if (_health == 0) 
        {
            Die();
        }
    }
        
    private void Die()
    {
        FindObjectOfType<AnimationManager>().Death();
        Destroy(gameObject);
        if (_lives > 0)
        {
            FindObjectOfType<GameManager>().ShowDeathWindow();
        }
        else 
        {
            FindObjectOfType<GameManager>().ShowLoseWindow();
        }
    }

    public void UpdateHealth()
    {
        _healthText.text = new string(_health.ToString() + "/" + _maxHealth.ToString()) ;
        float healthValue = ((float)_health) /((float)_maxHealth);
        _healthBar.value = healthValue;
    }
    public bool CheckHealth()
    {
        Debug.Log("Health "+ _health.ToString());
        if (_health > 0)
        {
            Debug.Log("Encresult True");
            return true; 
        }
        Debug.Log("Encresult False");
        return false;
    }
}
