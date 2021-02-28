using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class game_handler : MonoBehaviour
{
    int _blocks = 0;
    buttons_handler _buttons;
    [SerializeField] Text _score;
    int _current_score;
    int _increase_in_score = 10;
    private void Awake()
    {
        int elements = FindObjectsOfType<game_handler>().Length;
        if (elements > 1) { Destroy(this.gameObject); }
        else { DontDestroyOnLoad(this.gameObject); }
    }
    private void Start()
    {
        _buttons = FindObjectOfType<buttons_handler>();
        _current_score = 0;
        _increase_score();
    }
    private void Update()
    {
        if (_blocks <= 0)
        {
            _buttons.next();
        }
    }
    public void increase() { _blocks++; }
    public void decrease() 
    {
        _blocks--;
        _current_score += _increase_in_score;
        _increase_score();
    }
    void _increase_score() { _score.text = _current_score.ToString(); }

}
