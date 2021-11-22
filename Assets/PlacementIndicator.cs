using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlacementIndicator : MonoBehaviour
{

    // get the necessary components
    private ARRaycastManager rayManager;
    private GameObject visual;

    private void Start()
    {
        rayManager  = FindObjectOfType<ARRaycastManager>();
        visual = transform.GetChild(0).gameObject;

        // Dont show the placement marker till plane has been detected.
        visual.SetActive(false);


    }

    private void Update()
    {
        // shoot a raycast from the center of the screen

        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        
        // Cast the ray
        rayManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2),
            hits, TrackableType.Planes);

        // if we hit a AR plane, update the position and rotation of the ar object, (the placement marker in my case.)
        if (hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;

            if (!visual.activeInHierarchy)
            {
                visual.SetActive(true);
            }
        }
    }

}
