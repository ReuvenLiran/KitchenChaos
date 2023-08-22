using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    public override void Interact(Player player)
    {
        KitchenObject kitchenObjectToIntrect;

        if (!this.HasKitchenObject())
        {
            if (player.HasKitchenObject())
            {
                kitchenObjectToIntrect = player.GetKitchenObject();
                kitchenObjectToIntrect.SetKitchenObjectParent(this);
            }
        }
        else
        {
            if (!player.HasKitchenObject())
            {
                kitchenObjectToIntrect = this.GetKitchenObject();
                kitchenObjectToIntrect.SetKitchenObjectParent(player);
            }

        }
    }
}