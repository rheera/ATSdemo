using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FleaMarketScript : MonoBehaviour {

    public Text Selection;
    public Text Description;
    bool itemSelected = false;
	
	// Update is called once per frame
	public void SPDescription()
    {
        Selection.text = "Item: Silenced Pistol";
        Description.text = 
            "Price: $1,000,000\n\n" +
            "Description: Fires bullet with longer distance than dart with slienced noise";
        itemSelected = true;
    }
    public void GHDescription()
    {
        Selection.text = "Item: Grapling Hunk";
        Description.text =
            "Price: $1,000,000\n\n" +
            "Description: Throws a bulky male, which will support you to climb up the wall";
        itemSelected = true;
    }
    public void SGDescription()
    {
        Selection.text = "Item: Skunk Gas";
        Description.text =
            "Price: $1,000,000\n\n" +
            "Description: Throws a gas bomb which will distract the hound dogs";
        itemSelected = true;
    }
    public void MGDescription()
    {
        Selection.text = "Item: Machine Gun";
        Description.text =
            "Price: $1,000,000\n\n" +
            "Description: Fires bullets in rapid fire rate";
        itemSelected = true;
    }
    public void BSDescription()
    {
        Selection.text = "Item: Booster Shoes";
        Description.text =
            "Price: $1,000,000\n\n" +
            "Description: Increases your movement speed and jumps";
        itemSelected = true;
    }
    public void purchase()
    {
        if (itemSelected == true)
        {
            Description.text = "The seller is not available at Demo Version!!!";
        }
        else
        {
            Description.text = "Select an item to buy";
        }
    }
}
