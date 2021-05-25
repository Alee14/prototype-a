using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    public GameObject physGun;
    public GameObject cineCamera;

    private bool oneSelected = false;
    private bool twoSelected = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (oneSelected == false)
            {
                physGun.SetActive(true);
                oneSelected = true;
                Debug.Log("PhysGun selected");
            }
            else
            {
                physGun.SetActive(false);
                oneSelected = false;
                Debug.Log("PhysGun deselected");
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (twoSelected == false)
            {
                physGun.SetActive(true);
                twoSelected = true;
                if (oneSelected == true)
                {
                    oneSelected = false;   
                }
                Debug.Log("PhysGun selected");
            }
            else
            {
                physGun.SetActive(false);
                twoSelected = false;
                Debug.Log("PhysGun deselected");
            }
        }
    }
}
