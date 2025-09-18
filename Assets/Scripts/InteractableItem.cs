using UnityEngine;

public class InteractableItem : MonoBehaviour
{
    private ItemManager itemManager;

    private void Start()
    {
        itemManager = FindObjectOfType<ItemManager>();
    }


    private void OnMouseDown()
    {
        if(itemManager != null)
        {
            itemManager.PickUpItem(this.gameObject);
        }
    }


}
