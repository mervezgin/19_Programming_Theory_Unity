using System;
using UnityEngine;
public class ContainerCounter : BaseCounter
{
    public event EventHandler OnPlayerGrabbedObject;
    public override void Interact(PlayerController player)
    {
        if (!player.HasKitchenObject())
        {
            //player is not carrying anything
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(player);
            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        }
    }
}
