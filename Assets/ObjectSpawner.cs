using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ObjectSpawner : MonoBehaviour
{

    public GameObject objectToSpawn_0;
    public GameObject objectToSpawn_1;
    public GameObject objectToSpawn_2;
    public GameObject objectToSpawn_3;
    public GameObject objectToSpawn_4;

    private PlacementIndicator placementIndicator;
    //private List<GameObject> mList;
    private List<GameObject> mList = new List<GameObject>();
    private List<GameObject> mObjectList = new List<GameObject>();
    
    private bool flag_create_new = false;

    private int objectToSpawn_counter = 0;
    private int bush_counter_id = 4;


    private Dropdown mDropdown;
    // Start is called before the first frame update
    void Start()
    {
        placementIndicator = FindObjectOfType<PlacementIndicator>();

        mDropdown = GameObject.Find("ObjectSelectionDropdown").GetComponent<Dropdown>();

        // Add the objects to the list
        mObjectList.Add(objectToSpawn_0);
        mObjectList.Add(objectToSpawn_1);
        mObjectList.Add(objectToSpawn_2);
        mObjectList.Add(objectToSpawn_3);
        mObjectList.Add(objectToSpawn_4);


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
            Touch current_touch = Input.touches[0];

            int id = current_touch.fingerId;
            if (EventSystem.current.IsPointerOverGameObject(id))
            {
                // ui touched
            }
            else
            {

                // Touch is not on ui object. Proceed with spawning object

                objectToSpawn_counter = (int)mDropdown.value;

                GameObject obj = Instantiate(mObjectList[objectToSpawn_counter], 
                    placementIndicator.transform.position, placementIndicator.transform.rotation);

                // Add to the list
                mList.Add(obj);
                Debug.Log("Adding obejct In ObjectSpawner Update Loop. Object Count: " + mList.Count);

                //Set scale for bush object to be smaller.
                if (objectToSpawn_counter == bush_counter_id)
                {
                    obj.transform.localScale.Set(0.01f, 0.01f, 0.01f);
                }

            }

            ////Increment the counter and modulo the value 
            //objectToSpawn_counter++;
            //if (objectToSpawn_counter == 5)
            //{
            //    objectToSpawn_counter = 0;

            //}

        }

        //// Rotate each of the game objects that were spawned
        //int _rotationSpeed = 15;
        //if (mList.Count > 0)
        //{
        //    for (int i = 0; i<mList.Count; ++i)
        //    {
        //        // get current object
        //        GameObject currObject = mList[i];
        //        // Rotate the object
        //        // Rotate the object around its local X axis at 1 degree per second
        //        //currObject.transform.rotation.eulerAngles.Set(10.0f, 20.0f, 30.0f);
        //        currObject.transform.Rotate(0, _rotationSpeed * Time.deltaTime, 0);
        //        //currObject.transform.Rotate(Vector3.up * 2, Space.World);

        //        // ...also rotate around the World's Y axis
        //        //currObject.transform.Rotate(Vector3.up * 2, Space.World);
        //    }

        //}

    }
}
