using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Code taken from UMod
    public float MoveSpeed = 4f;
    public float MouseSensitivity = 1f;
    public float MoreSpeed = 10f;
    public bool yLock = false;
    private float fastSpeed;
    private bool sprint = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        fastSpeed = MoveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        var mouseX = Input.GetAxisRaw("Mouse X");
        var mouseY = -Input.GetAxisRaw("Mouse Y");
        var rot = Camera.main.transform.eulerAngles;
        var rotationVector = new Vector3(mouseY, mouseX, 0);
        rot += rotationVector * MouseSensitivity;
        Camera.main.transform.rotation = Quaternion.Euler(rot);
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            fastSpeed = MoveSpeed + MoreSpeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            fastSpeed = MoveSpeed;
        }
        var sideMove = Input.GetAxisRaw("Horizontal");
        var forwardMove = Input.GetAxisRaw("Vertical");
        var moveVector = new Vector3(sideMove, 0, forwardMove) * fastSpeed;
        moveVector = Camera.main.transform.TransformDirection(moveVector);
        if (yLock == true)
        {
            moveVector.y = 0;
        }

        transform.Translate(moveVector * Time.deltaTime);
    }
}
