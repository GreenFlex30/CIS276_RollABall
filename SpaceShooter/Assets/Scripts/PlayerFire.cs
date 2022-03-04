using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject PlayerLaser;
    public GameObject PlayerMine;

    public bool weaponType = true;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump") && weaponType == true)
        {
            weaponType = false;
        }
        else if(Input.GetButtonDown("Jump") && weaponType == false)
        {
            weaponType = true;
        }

        if (Input.GetButtonDown("Fire1") && weaponType == true)
        {
            GameObject laser;
            laser = Instantiate(PlayerLaser, transform);

            laser.GetComponent<Rigidbody>().AddForce(Vector2.up * 30f, ForceMode.Impulse);
        }
        else if(Input.GetButtonDown("Fire1") && weaponType == false)
        {
            GameObject mine;
            mine = Instantiate(PlayerMine, transform);
        }
    }
}
