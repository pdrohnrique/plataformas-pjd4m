using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private Rigidbody _rb;
    private int _coinCount = 0;
    private Vector2 _moveInput;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    
    private void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(_moveInput.x, 0, _moveInput.y) * speed;
        _rb.linearVelocity = movement;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            _coinCount++;
            PlayerOm.NotifyCoinCollected(_coinCount);
            Destroy(other.gameObject);
        }
    }
}
