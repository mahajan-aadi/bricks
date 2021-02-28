using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttons_handler : MonoBehaviour
{
    public void start_game()
    {
        SceneManager.LoadScene(0);
    }
    public void next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex  +  1);
    }
    public void exit()
    {
        Application.Quit();
    }
}
