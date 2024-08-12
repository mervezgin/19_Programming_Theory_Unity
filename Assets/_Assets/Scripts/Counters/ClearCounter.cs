using UnityEngine;
public class ClearCounter : BaseCounter
{

    public override void Interact(PlayerController player)
    {
        if (!HasKitchenObject())
        {
            //there is no kitchenobject here
            if (player.HasKitchenObject())
            {
                //player is carrying sth
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else
            {
                //player is not carrying anything 
            }
        }
        else
        {
            //there is a kitchenobject here
            if (player.HasKitchenObject())
            {
                //player is carrying sth
            }
            else
            {
                //player is not carrying anything
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
}
