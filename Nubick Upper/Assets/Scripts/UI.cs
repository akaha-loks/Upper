using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public void LoadSceneId(int scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void LoadSceneName(string scene)
    {
        SceneManager.LoadScene(scene);

    }
}