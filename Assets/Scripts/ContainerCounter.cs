using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ContainerCounter : BaseCounter
{
    [SerializeField] protected KitchenObjectSO kitchenObjectSO;

    public event EventHandler OnPlayerGrabbedObject;

    public override void Interact(Player player)
    {
        if (!player.HasKitchenObject())
        {
            KitchenObject kitchenObjectToIntrect;
            kitchenObjectToIntrect = KitchenObject.Spawn(kitchenObjectSO, this);
            kitchenObjectToIntrect.SetKitchenObjectParent(player);
            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        }
    }
}