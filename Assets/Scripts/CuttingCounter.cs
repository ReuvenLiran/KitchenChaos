using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private CuttingRecipeSO[] cuttingRecipeSOArray;

    public override void Interact(Player player)
    {
        KitchenObject kitchenObjectToIntrect;

        if (!HasKitchenObject())
        {
            if (player.HasKitchenObject())
            {
                kitchenObjectToIntrect = player.GetKitchenObject();
                bool hasRecipe = FindRecipe(kitchenObjectToIntrect) != null;

                if (hasRecipe)
                {
                    kitchenObjectToIntrect.SetKitchenObjectParent(this);
                }
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

    public override void InteractAlternate(Player player)
    {
        KitchenObject kitchenObjectToIntrect;

        if (HasKitchenObject())
        {
            kitchenObjectToIntrect = GetKitchenObject();
            CuttingRecipeSO cuttingRecipeSO = FindRecipe(kitchenObjectToIntrect);

            if (cuttingRecipeSO != null)
            {
                kitchenObjectToIntrect.DestroySelft();
                KitchenObject.Spawn(cuttingRecipeSO.output, this);
            }
        }
    }

    private CuttingRecipeSO FindRecipe(KitchenObject kitchenObject)
    {
        KitchenObjectSO kitchenObjectSO = kitchenObject.GetKitchenObjectSO();

        CuttingRecipeSO cuttingRecipeSO = Array.Find(cuttingRecipeSOArray, recipe => kitchenObjectSO == recipe.input);
        return cuttingRecipeSO;
    }
}
