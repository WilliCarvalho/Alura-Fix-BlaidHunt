using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private float jumpForce = 3;
    
    private Rigidbody2D rigidbody;
    private IsGroundedChecker isGroundedCheker;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        isGroundedCheker = GetComponent<IsGroundedChecker>();
    }

    private void Start()
    {
        GameManager.Instance.InputManager.OnJump += HandleJump;
    }

    private void Update()
    {
        float moveDirection = GameManager.Instance.InputManager.Movement;
        transform.Translate(moveDirection * Time.deltaTime * moveSpeed, 0, 0);
    }

    private void HandleJump()
    {
        if (isGroundedCheker.IsGrounded() == false) return;
        rigidbody.velocity += Vector2.up * jumpForce;
    }
}
