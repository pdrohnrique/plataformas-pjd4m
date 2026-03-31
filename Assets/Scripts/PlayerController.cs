using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody _rb;
    private Vector3 _input;
    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        _input = new Vector3(x, 0, z);
    }

    void FixedUpdate()
    {
        _rb.linearVelocity = new Vector3(_input.x * speed, 0, _input.z * speed);
    }
}
