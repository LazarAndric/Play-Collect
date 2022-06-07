using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUP : MonoBehaviour
{
    public Transform Inventory;
    public Transform Hand;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    int itemIndex = 0;
    // Update is called once per frame
    void Update()
    {
        int itemsCount = Inventory.childCount;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hitInfo;

            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit)
            {
                if (hitInfo.collider.tag == "Item")
                {
                    hitInfo.transform.SetParent(Inventory);
                    hitInfo.transform.position = Inventory.position;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (itemIndex> itemsCount-1)
            {
                itemIndex = 0;
            }
            if (Hand.childCount == 0)
            {
                Inventory.GetChild(itemIndex).SetParent(Hand);
                Hand.GetChild(0).position = Hand.position;
                itemIndex++;
            }
            else
            {
                Hand.GetChild(0).position = Inventory.position;
                Hand.GetChild(0).SetParent(Inventory);

                Inventory.GetChild(itemIndex).SetParent(Hand);
                Hand.GetChild(0).position = Hand.position;
                itemIndex++;
            }

        }

    }
}
