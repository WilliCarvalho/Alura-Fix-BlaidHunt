using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        bool isMoving = GameManager.Instance.InputManager.Movement != 0;
        animator.SetBool("isMoving", isMoving);
    }
}
