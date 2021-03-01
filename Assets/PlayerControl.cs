using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    private bool _wInput = false;
    private bool _aInput = false;
    private bool _sInput = false;
    private bool _dInput = false;


    void Start()
    {
        
    }
    private void OnEnable()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Vector3 movement = Vector3.zero;

        if (_wInput) movement += Vector3.up ;
        if (_aInput) movement += Vector3.left;
        if (_sInput) movement += Vector3.down;
        if (_dInput) movement += Vector3.right;
        movement = movement * Time.deltaTime;
        transform.position = transform.position + movement;

    }

    public void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.W)) _wInput = true;
        if (Input.GetKeyUp(KeyCode.W)) _wInput = false;
        if (Input.GetKeyDown(KeyCode.A)) _aInput = true;
        if (Input.GetKeyUp(KeyCode.A)) _aInput = false;
        if (Input.GetKeyDown(KeyCode.S)) _sInput = true;
        if (Input.GetKeyUp(KeyCode.S)) _sInput = false;
        if (Input.GetKeyDown(KeyCode.D)) _dInput = true;
        if (Input.GetKeyUp(KeyCode.D)) _dInput = false;
    }
}
