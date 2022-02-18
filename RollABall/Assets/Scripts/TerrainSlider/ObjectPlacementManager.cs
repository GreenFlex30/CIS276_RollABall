using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacementManager : MonoBehaviour
{
    public Transform placeableObject;
    // Assigned in Inspector
    public Camera cam;
    public LayerMask mask;
    // boolean for placing obj
    public bool canPlace = true;

    

    public void Awake()
    {
        cam = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if(Physics.Raycast(ray, out hitInfo, Mathf.Infinity, mask))
        {
            placeableObject.position = hitInfo.point + new Vector3(0, 0.5f, 0);
            placeableObject.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
        }

        if(Input.GetButtonDown("Fire1") && canPlace == true)
        {
            // Duplicate of cube is made
            Transform dupe;
            dupe = Instantiate(placeableObject, transform);

            // disables ability to place cube and disables render for cube
            canPlace = false;
            placeableObject.GetComponentInChildren<Renderer>().enabled = false;
        }
        if(Input.GetButtonDown("Fire2"))
        {
            // re-enables render and ability to place cube
            canPlace = true;
            placeableObject.GetComponentInChildren<Renderer>().enabled = true;
        }
    }
}
