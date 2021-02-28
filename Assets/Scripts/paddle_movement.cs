using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddle_movement : MonoBehaviour
{
    [SerializeField] float _pixel_width = 8.89f;
    [SerializeField] float _restricted = 7.55f;

    // Update is called once per frame
    void Update()
    {
        movement();
        
    }

    private void movement()
    {
        float x_axis = Input.mousePosition.x;
        float y_axis = transform.position.y;
        float z_axis = transform.position.z;
        float screen_width = Screen.width / 2;
        float move_x=((x_axis-screen_width)/ screen_width)*_pixel_width;
        move_x = Mathf.Clamp(move_x, -_restricted, _restricted);
        transform.position=new Vector3(move_x, y_axis, z_axis);
    }
}
