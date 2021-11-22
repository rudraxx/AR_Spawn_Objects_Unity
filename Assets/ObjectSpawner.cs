using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectSpawner : MonoBehaviour
{

    public GameObject objectToSpawn;
    private PlacementIndicator placementIndicator;
    //private List<GameObject> mList;
    private List<GameObject> mList = new List<GameObject>();
    private bool flag_create_new = false;


    // Start is called before the first frame update
    void Start()
    {
        placementIndicator = FindObjectOfType<PlacementIndicator>();

        
    }

    // Update is called once per frame
    void Update()
    {

        ////Debug.Log("In ObjectSpawner Update Loop." + System.DateTime.Now.Second);

        //if ( ((int)System.DateTime.Now.Second % 10 == 0) && flag_create_new)
        //{
        //    GameObject obj = Instantiate(objectToSpawn,
        //        placementIndicator.transform.position, placementIndicator.transform.rotation);

        //    // Add to the list
        //    mList.Add(obj);
        //    // 
        //    Debug.Log("Adding obejct In ObjectSpawner Update Loop. Object Count: " + mList.Count);

        //    flag_create_new = false;
        //}

        //if ((int)System.DateTime.Now.Second % 10 == 1)
        //{
        //    flag_create_new = true;
        //}

        // Check for touch input
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            GameObject obj = Instantiate(objectToSpawn, 
                placementIndicator.transform.position, placementIndicator.transform.rotation);

            // Add to the list
            mList.Add(obj);
            Debug.Log("Adding obejct In ObjectSpawner Update Loop. Object Count: " + mList.Count);

        }

        // Rotate each of the game objects that were spawned
        int _rotationSpeed = 15;
        if (mList.Count > 0)
        {
            for (int i = 0; i<mList.Count; ++i)
            {
                // get current object
                GameObject currObject = mList[i];
                // Rotate the object
                // Rotate the object around its local X axis at 1 degree per second
                //currObject.transform.rotation.eulerAngles.Set(10.0f, 20.0f, 30.0f);
                currObject.transform.Rotate(0, _rotationSpeed * Time.deltaTime, 0);
                //currObject.transform.Rotate(Vector3.up * 2, Space.World);

                // ...also rotate around the World's Y axis
                //currObject.transform.Rotate(Vector3.up * 2, Space.World);
            }

        }

    }
}
