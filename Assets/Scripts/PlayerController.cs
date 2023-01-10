using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Animator _animator;

    [SerializeField] private CharacterController _characterController;
    private float _eulerAngleLimit = 70;
    private float _positionLimitX = 2.5f;
    private float _oldMousePositionX;
    private float _eulerY;
    private float _positionY = 0f;
    private Tutorial _tutorial;

    private void Start()
    {
        _tutorial = FindObjectOfType<Tutorial>();
    }
    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetMouseButtonDown(0))
        {
            _oldMousePositionX = Input.mousePosition.x;
            _animator.SetBool("Run_b", true);
            _tutorial.DeactivateTutorial();
        }

        if (Input.GetMouseButton(0))
        {
            _characterController.Move(transform.forward * _speed * Time.deltaTime);

            Vector3 newPosition = transform.position;
            newPosition.x = Mathf.Clamp(newPosition.x, -_positionLimitX, _positionLimitX);
            newPosition.y = _positionY;
            transform.position = newPosition;


            float deltaX = (Input.mousePosition.x - _oldMousePositionX) / 6;
            _oldMousePositionX = Input.mousePosition.x;

            _eulerY += deltaX;
            _eulerY = Mathf.Clamp(_eulerY, -_eulerAngleLimit, _eulerAngleLimit);
            transform.eulerAngles = new Vector3(0, _eulerY, 0);
        }
        if (Input.GetMouseButtonUp(0))
        {
            _animator.SetBool("Run_b", false);
            _tutorial.ActivateTutorial();
        }

    }
}
