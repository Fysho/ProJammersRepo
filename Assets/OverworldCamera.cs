using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldCamera : MonoBehaviour
{
    // Start is called before the first frame update
    private float _startX;
    private float _startY;
    private float _startZ;
    private float _moveOffsetPixels = 200;
    private float _maxSpeed = 5;

    void Start()
    {
        _startX = transform.position.x;
        _startX = transform.position.x;
        _startX = transform.position.x;

    }

    // Update is called once per frame
    void Update()
    {
        int screenWidth = Screen.width;
        int screenHeight = Screen.height;
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.x;

        if (screenWidth - mouseX < _moveOffsetPixels)
        {
            float speed = _maxSpeed * (1-((screenWidth - mouseX) / _moveOffsetPixels));
            if (speed > _maxSpeed) speed = _maxSpeed;
            transform.position = transform.position + new Vector3(speed * Time.deltaTime,0,0);
        }
        if (0 + mouseX < _moveOffsetPixels)
        {
            float speed = _maxSpeed * (1 - ((0 + mouseX) / _moveOffsetPixels));
            if (speed > _maxSpeed) speed = _maxSpeed;
            transform.position = transform.position - new Vector3(speed * Time.deltaTime, 0, 0);
        }
    }
}
