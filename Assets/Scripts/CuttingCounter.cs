using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private CuttingRecipeSO[] cuttingRecipeSOArray;
    private float cuttingProgress;

    public event EventHandler<OnProgressChangedArgs> OnProgressChanged;
    public class OnProgressChangedArgs : EventArgs
    {
        public float progressNormalized;
    }

    public event EventHandler OnCut;

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
                    ClearProgress();
                }
            }
        }
        else
        {
            if (!player.HasKitchenObject())
            {
                kitchenObjectToIntrect = this.GetKitchenObject();
                kitchenObjectToIntrect.SetKitchenObjectParent(player);
                ClearProgress();
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

            cuttingProgress++;
            SendProgress(cuttingProgress / cuttingRecipeSO.cuttingProgressMax);

            OnCut?.Invoke(this, EventArgs.Empty);

            if (cuttingRecipeSO != null && cuttingProgress >= cuttingRecipeSO.cuttingProgressMax)
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

    private void SendProgress(float precent)
    {
        OnProgressChanged?.Invoke(this, new OnProgressChangedArgs
        {
            progressNormalized = precent
        });
    }

    private void ClearProgress()
    {
        cuttingProgress = 0;
        SendProgress(0);
    }
}
