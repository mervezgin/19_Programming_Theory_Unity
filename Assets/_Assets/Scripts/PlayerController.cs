using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameInput gameInput;
    private float moveSpeed = 7.0f;
    private float rotateSpeed = 10f;
    private float playerRadius = 0.75f;
    private float playerHeight = 2.0f;
    private bool isWalking;
    void Update()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDirection = new Vector3(inputVector.x, 0, inputVector.y);

        float moveDistance = moveSpeed * Time.deltaTime;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirection, moveDistance);

        if (!canMove)
        {
            //cannot move towards moveDirection 

            //Attempt only X movement
            Vector3 moveDirectionX = new Vector3(moveDirection.x, 0, 0).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirectionX, moveDistance);
            if (canMove)
            {
                //can move only on the X 
                moveDirection = moveDirectionX;
            }
            else
            {
                //cannot move only on the X 

                //Attempt only Z movement 
                Vector3 moveDirectionZ = new Vector3(0, 0, moveDirection.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirectionZ, moveDistance);

                if (canMove)
                {
                    //can move only on the Z
                    moveDirection = moveDirectionZ;
                }
                else
                {
                    //cannot move any direction 
                }
            }
        }
        if (canMove)
        {
            transform.position += moveDirection * moveDistance;
        }
        isWalking = moveDirection != Vector3.zero;

        transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);
    }

    public bool IsWalking()
    {
        return isWalking;
    }
}
