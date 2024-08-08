using UnityEngine;
public class BaseCounter : MonoBehaviour, IKitchenObjectParent
{
    [SerializeField] public KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform counterTopPoint;

    private KitchenObject kitchenObject;
    public virtual void Interact(PlayerController player)
    {
        Debug.LogError("BaseCounter.Interact();");
    }
    public Transform GetKitchenObjectFollowTransform() { return counterTopPoint; }
    public void SetKitchenObject(KitchenObject kitchenObject) { this.kitchenObject = kitchenObject; }
    public KitchenObject GetKitchenObject() { return kitchenObject; }
    public void ClearKitchenObject() { kitchenObject = null; }
    public bool HasKitchenObject() { return kitchenObject != null; }
}
