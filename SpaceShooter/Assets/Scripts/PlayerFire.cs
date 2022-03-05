using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // variables and objects made
    public GameObject PlayerLaser;
    public GameObject PlayerMine;

    public bool weaponType = true;

    // Update is called once per frame
    void Update()
    {
        // switching weapons
        if(Input.GetButtonDown("Jump") && weaponType == true)
        {
            // laser weapon
            weaponType = false;
        }
        else if(Input.GetButtonDown("Jump") && weaponType == false)
        {
            // mine weapon
            weaponType = true;
        }

        // left-click will use weapon
        if (Input.GetButtonDown("Fire1") && weaponType == true)
        {
            // a laser will spawn every click
            GameObject laser;
            laser = Instantiate(PlayerLaser, transform);

            laser.GetComponent<Rigidbody>().AddForce(Vector2.up * 30f, ForceMode.Impulse);
        }
        else if(Input.GetButtonDown("Fire1") && weaponType == false)
        {
            // a mine will spawn whereever the player is
            GameObject mine;
            mine = Instantiate(PlayerMine, transform);
        }
    }
}
