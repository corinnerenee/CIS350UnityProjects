using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    //reference to item
    [SerializeField] private InventoryItem item;
    public List<InventoryItem> inventory;
    
    // Use this for initialization
    void Start()
    {
        item = new InventoryItem();
        inventory = new List<InventoryItem>(); //calling constructor
    }

    // Update is called once per frame
    void Update()
    {

    }
}
