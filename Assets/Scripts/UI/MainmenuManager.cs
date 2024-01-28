using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainmenuManager : MonoBehaviour
{
    [SerializeField] private GameObject setting;

    public void Start()
    {
    }

    public void play()
    {
        SceneManager.LoadScene("Level_1");
    }
    
    public void QuitGame()
    {
#if UNITY_EDITOR
        // Unity Editör içinde çalışıyorsa, oyunu durdur
        UnityEditor.EditorApplication.isPlaying = false;
#else
            // Unity Editör dışında (oyun halinde) ise, uygulamadan çık
            Application.Quit();
#endif
    }

    public void settings()
    {
        setting.SetActive(true);
    }

    public void closesetting()
    {
        setting.SetActive(false);
    }
}
