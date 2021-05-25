using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    public GameObject physGun;

    private bool oneSelected = false;
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
    }
}
