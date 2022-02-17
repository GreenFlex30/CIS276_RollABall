using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacementManager : MonoBehaviour
{
    public Transform placeableObject;
    // Assigned in Inspector
    public Camera cam;
    public LayerMask mask;
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
            Transform dupe;
            dupe = Instantiate(placeableObject, transform);
            //Destroy(placeableObject);
            canPlace = false;
        }
        if(Input.GetButtonDown("Fire2"))
        {
            //placeableObject = Instantiate(placeableObject);
            canPlace = true;
        }
    }
}
