using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class EncounterTooltip : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    [SerializeField] private Image _glassImage;
    [SerializeField] private GameObject _zoneBox;

    [SerializeField] private GameObject _healModel;
    [SerializeField] private GameObject _fightModel;

    //Material for Interraction zone
    [SerializeField] private Material _healZoneMaterial;
    [SerializeField] private Material _fightZoneMaterial;

    //Overhead tooltip background color
    [SerializeField] private Color _colorHeal;
    [SerializeField] private Color _colorFight;

    //Icons of heal/overheal for Healing
    [SerializeField] private GameObject _healLable;
    [SerializeField] private GameObject _ovehealLable;
    //Icons of damage/death for Fighting
    [SerializeField] private GameObject _fightLable;
    [SerializeField] private GameObject _deathLable;

    [SerializeField] private PlayerModifier _playerModifier;

    public void UpdateVisual(int value)
    {
        string prefix = "";

        _healLable.SetActive(false);
        _ovehealLable.SetActive(false);
        _fightLable.SetActive(false);
        _deathLable.SetActive(false);

        if (value > 0)
        {
            _fightModel.SetActive(false);
            _healModel.SetActive(true);
            _healLable.SetActive(true);
            _zoneBox.SetActive(true);
            SetColor(_colorHeal);
            prefix = "+";
            _zoneBox.GetComponent<Renderer>().material = _healZoneMaterial;

            // if overheal _ovehealLable.SetActive(true);


        }
        else if (value == 0)
        {
            prefix = "";
            SetColor(Color.grey);
            _fightModel.SetActive(false);
            _healModel.SetActive(false);
            _zoneBox.SetActive(false);
        }
        else
        {
            _healModel.SetActive(false);
            _fightModel.SetActive(true);
            _fightLable.SetActive(true);
            _zoneBox.SetActive(true);
            SetColor(_colorFight);
            _zoneBox.GetComponent<Renderer>().material = _fightZoneMaterial;

            // if dmg more than HP = _deathLable.SetActive(true);
        }

        _text.text = prefix + value.ToString();

              
    }

    void SetColor(Color color)
    {
        _glassImage.color = new Color(color.r, color.g, color.b, 0.5f);
    }

    public void AttackAnimation() 
    {
        if (_fightModel.GetComponentInChildren<Animator>() != null)
        {
            Animator childAnimator = GetComponentInChildren<Animator>();
            childAnimator.SetTrigger("Attack_t");
        }
    }
}
