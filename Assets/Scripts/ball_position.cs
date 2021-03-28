using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_position : MonoBehaviour
{
    [SerializeField] AudioClip _col;
    [SerializeField] float _random_factor;
    [SerializeField] float _initial_velx;
    [SerializeField] float _initial_vely;
    bool _started = false;
    float _initial_y;
    float _initial_x;
    paddle_movement _paddle;
    Rigidbody2D _rigid;
    // Start is called before the first frame update
    void Start()
    {
        _paddle = GameObject.FindObjectOfType<paddle_movement>();
        _initial_y = transform.position.y;
        _initial_x = transform.position.x- _paddle.transform.position.x;
        _rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10f) { Destroy(this.gameObject); }
        if (!_started) { start_position(); move(); }
    }

    private void move()
    {
        _rigid.velocity = new Vector2(_initial_velx,_initial_vely);
    }

    private void start_position()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            _started = true; 
        }
        else
        {
            float x_axis = _paddle.transform.position.x;
            float z_axis = transform.position.z;
            transform.position = new Vector3(_initial_x+x_axis, _initial_y, z_axis);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(_col,Camera.main.transform.position);
        _rigid.velocity += new Vector2(
            UnityEngine.Random.Range(-_random_factor, _random_factor),
            UnityEngine.Random.Range(-_random_factor, _random_factor));

    }
}
