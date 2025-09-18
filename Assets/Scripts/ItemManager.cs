using UnityEngine;

public class ItemManager : MonoBehaviour
{

    public Transform handTransform;

    public Transform lampPlacementZone;

    private GameObject currentlyHeldItem = null;
    private bool canManageItems = false;

   

    // Update is called once per frame
    void Update()
    {

        if (!canManageItems) return;

        if(currentlyHeldItem != null && Input.GetMouseButtonDown(0))
        {
            PlaceItem();
        }

    }

    public void PickUpItem(GameObject itemToPickUp)
    {
        currentlyHeldItem = itemToPickUp;
        currentlyHeldItem.transform.SetParent(handTransform);

        currentlyHeldItem.transform.localPosition = Vector3.zero;

    }

    public void PlaceItem()
    {

        currentlyHeldItem.transform.SetParent(null);

        currentlyHeldItem.transform.position = lampPlacementZone.position;

        currentlyHeldItem = null;

        DisableItemManagment();


    }

    public void EnableItemManagment()
    {
        canManageItems = true;
    }

    public void DisableItemManagment()
    {

        canManageItems = false;

    }





}
