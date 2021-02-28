using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class losing : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int elements = FindObjectsOfType<ball_position>().Length;
        Destroy(collision.gameObject);
        if (elements == 1) { FindObjectOfType<buttons_handler>().start_game(); }
    }

}
