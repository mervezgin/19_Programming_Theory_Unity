using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] PlayerController player;
    Animator animator;
    const string IS_WALKING = "IsWalking";

    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        animator.SetBool(IS_WALKING, player.IsWalking());
    }
}
