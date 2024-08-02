using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameInput gameInput;
    private float moveSpeed = 7.0f;
    private float rotateSpeed = 10f;
    private bool isWalking;
    void Update()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        Vector3 moveDirection = new Vector3(inputVector.x, 0, inputVector.y);
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
        isWalking = moveDirection != Vector3.zero;

        transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);
    }

    public bool IsWalking()
    {
        return isWalking;
    }
}
