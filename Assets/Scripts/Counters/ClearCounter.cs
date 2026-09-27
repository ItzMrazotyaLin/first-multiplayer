using System;
using Unity.VisualScripting;
using UnityEngine;

public class ClearCounter : BaseCounter, IKitchenObjectParent
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            if (player.HasKitchenObject())
            {
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else
            {

            }
        } else
        {
            if (player.HasKitchenObject())
            {
                
            }
            else
            {
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
}
