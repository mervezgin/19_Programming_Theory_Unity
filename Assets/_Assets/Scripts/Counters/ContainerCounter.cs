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
            KitchenObject.SpawnKitchenObject(kitchenObjectSO, player);
            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        }
    }
}
