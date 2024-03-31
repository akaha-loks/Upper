using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public bool isMainMenu = true;
    private void Awake()
    {
        if (isMainMenu == false)
        {
            Invoke("GetStartGame", 0.3f);
        }
        else
        {
            Time.timeScale = 1;
            if(PlayerPrefs.GetInt("audioTrue") == 0)
            {
                PlayerPrefs.SetFloat("volume", 1);
            }
        }
    }
    private void GetStartGame()
    {
        Time.timeScale = 0;
        PlayerPrefs.SetFloat("lvl", 0);
        PlayerPrefs.SetFloat("speedPlatform", 5);
    }
}
