using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private float _speed;
    [SerializeField] private float _tapForce = 10;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;

    private PlayerAnimator _playerAnimator;
    private Rigidbody2D _rigidBody;
    private PlayerCollisionHandler _playerCollisionHandler;
    private bool _isOnGround;

    private Quaternion _minRotation;
    private Quaternion _maxRotation;

    private void Awake()
    {
        _playerCollisionHandler = GetComponent<PlayerCollisionHandler>();
    }
    
    private void Start()
    {
        _isOnGround = false;
        _rigidBody = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<PlayerAnimator>();
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);

        ResetPlayerCoordinates();
    }
    private void OnEnable()
    {
        _playerCollisionHandler.Grounded += OnGrounded;
    }

    private void OnDisable()
    {
        _playerCollisionHandler.Grounded -= OnGrounded;
    }

    private void Update()
    {
        if (_isOnGround)
        {
            _rigidBody.velocity = new Vector2(_speed, 0);
        }
        
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            _isOnGround = false;
            _rigidBody.velocity = new Vector2(_speed, 0);
            transform.rotation = _maxRotation;
            _rigidBody.AddForce(Vector2.up * _tapForce, ForceMode2D.Force);
            _playerAnimator.PlayRocketJumpAnimation();
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    private void OnGrounded()
    { 
        _isOnGround = true;
    }

    public void ResetPlayerCoordinates()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        _rigidBody.velocity = Vector2.zero;
    }
}
