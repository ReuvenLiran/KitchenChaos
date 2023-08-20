using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : MonoBehaviour, IKitchenObjectParent
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform counterTopPoint;

    private KitchenObject kitchenObject;

    public void ClearKitchenObject()
    {
        throw new System.NotImplementedException();
    }

    public KitchenObject GetKitchenObject()
    {
        throw new System.NotImplementedException();
    }

    public Transform GetKitchenObjectFollowTransform()
    {
        throw new System.NotImplementedException();
    }

    public bool HasKitchenObject()
    {
        throw new System.NotImplementedException();
    }

    public void Interact(Player player)
    {
        if (kitchenObject == null)
        {
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab, counterTopPoint);
            kitchenObjectTransform.localPosition = Vector3.zero;

            kitchenObject = kitchenObjectTransform.GetComponent<KitchenObject>();
            kitchenObject.SetKitchenObjectParent(this);
        }
        else
        {
            Debug.Log(kitchenObject.GetKitchenObjectParent());
            kitchenObject.SetKitchenObjectParent(player);
        }
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        throw new System.NotImplementedException();
    }
}
