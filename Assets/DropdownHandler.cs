using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownHandler : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

        // Create the dropdown
        var dropdown = transform.GetComponent<Dropdown>();
        dropdown.options.Clear();

        List<string> items = new List<string>();
        items.Add("Cube");
        items.Add("Grass");
        items.Add("Weed");
        items.Add("AnotherWeed");
        items.Add("Bush");

        foreach(var item in items)
        {
            dropdown.options.Add(new Dropdown.OptionData() { text = item });
        }

        //dropdown.onValueChanged.AddListener(delegate { DropdownItemSelected(dropdown); });
    }

    private void DropdownItemSelected(Dropdown dropdown)
    {
        //int index = dropdown.value;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
