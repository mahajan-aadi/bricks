using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttons_handler : MonoBehaviour
{
    game_handler game;
    private void Start()
    {
        game = FindObjectOfType<game_handler>();
    }
    void reset()
    {
        game.new_level();
    }
    public void start_game()
    {
        SceneManager.LoadScene(0);
    }
    public void lost()
    {
        reset();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void next()
    {
        reset();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex  +  1);
    }
    public void exit()
    {
        Application.Quit();
    }
}
