using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 6f;
    [SerializeField] private float rotation = 0.15f; // mouse/look sensitivity
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float minPitch = -80f;
    [SerializeField] private float maxPitch = 80f;

    private Rigidbody _rb;
    private Vector2 _movement;
    private Vector2 _cameraInput;
    private float _pitch;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Called by PlayerInput (Behavior = Send Messages), action name must be Move
    public void OnMove(InputValue value)
    {
        _movement = value.Get<Vector2>();
    }

    // Called by PlayerInput (Behavior = Send Messages), action name must be Look
    public void OnLook(InputValue value)
    {
        _cameraInput = value.Get<Vector2>();
    }

    void Update()
    {
        // Yaw: rotate player left/right
        float yaw = _cameraInput.x * rotation;
        transform.Rotate(0f, yaw, 0f);

        // Pitch: rotate camera up/down with clamp
        _pitch -= _cameraInput.y * rotation;
        _pitch = Mathf.Clamp(_pitch, minPitch, maxPitch);
        playerCamera.transform.localRotation = Quaternion.Euler(_pitch, 0f, 0f);
    }

    void FixedUpdate()
    {
        // Convert 2D move input into world-space direction based on player facing
        Vector3 move = transform.right * _movement.x + transform.forward * _movement.y;
        if (move.sqrMagnitude > 1f) move.Normalize(); // prevent diagonal speed boost

        Vector3 current = _rb.linearVelocity;
        Vector3 targetHorizontal = move * speed;

        // Keep vertical velocity so gravity still works
        _rb.linearVelocity = new Vector3(targetHorizontal.x, current.y, targetHorizontal.z);
    }
}