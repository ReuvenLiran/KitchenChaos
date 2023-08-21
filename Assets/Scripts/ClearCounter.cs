using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    KitchenObject kitchenObject;

    public override void Interact(Player player)
    {
        if (!this.HasKitchenObject())
        {
            if (player.HasKitchenObject())
            {
                kitchenObject = player.GetKitchenObject();
                kitchenObject.SetKitchenObjectParent(this);
            }
        }
        else
        {
            if (!player.HasKitchenObject())
            {
                kitchenObject = this.GetKitchenObject();
                kitchenObject.SetKitchenObjectParent(player);
            }

        }
    }
}