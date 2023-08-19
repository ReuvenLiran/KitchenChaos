using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    private ClearCounter clearCounter;

    public KitchenObjectSO GetKitchenObjectSO()
    {
        return kitchenObjectSO;
    }

    public void SetClearCounter(ClearCounter newClearCounter)
    {
        // Check previous ClearCounter
        if (this.clearCounter != null)
        {
            this.clearCounter.ClearKitchenObject();
        }
        this.clearCounter = newClearCounter;

        if (newClearCounter.HasKitchenObject())
        {
            Debug.LogError(newClearCounter + " is full");
        }

        newClearCounter.SetKitchenObject(this);

        transform.parent = newClearCounter.GetKitchenObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }

    public ClearCounter GetClearCounter()
    {
        return this.clearCounter;
    }
}
