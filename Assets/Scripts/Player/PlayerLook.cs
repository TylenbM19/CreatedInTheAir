using UnityEngine;


public class PlayerLook : MonoBehaviour
{
    [SerializeField] private float _verticalRotationSpeed;
    [SerializeField] private float _horizontalRotationSpeed;
    [SerializeField] private VerticalLook _verticalLook ;

    private PlayerInput _playerInput;
    private Vector2 _rotate;
    private Vector2 _rotation;
    private Vector2 _verticalRotation = Vector2.zero;

    private void Awake()
    {
        _playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void Update()
    {
        _rotate = _playerInput.Player.Look.ReadValue<Vector2>();

        Look(_rotate);
    }

    private void Look(Vector2 rotate)
    {
        if (rotate.sqrMagnitude < 0.1)
            return;

        _rotation.y += rotate.x * _horizontalRotationSpeed * Time.deltaTime;
        transform.localEulerAngles = _rotation;

        _verticalRotation.x = Mathf.Clamp((_verticalRotation.x + (-rotate.y* Time.deltaTime * _verticalRotationSpeed)) , -45, 45);
        _verticalLook.transform.localEulerAngles = _verticalRotation;
    }
}
