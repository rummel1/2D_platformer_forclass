using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private AudioClip _gameOverSound;
    [SerializeField] private GameObject _escPanel;
    [SerializeField] private GameObject _settingPanel;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_escPanel.activeSelf)
                ClosePanel();
            else
                OpenPanel();
        }
    }

    public void OpenPanel()
    {
        _escPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ClosePanel()
    {
        _escPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main_menu");
    }
    public void InGameSettings()
    {
        _settingPanel.SetActive(true);
    }
    public void InGameCloseSetting()
    {
        _settingPanel.SetActive(false);
    }

    public void GameOver()
    {
        _gameOverScreen.SetActive(true);
        SoundManager.instance.PlaySound(_gameOverSound);
    }

    public void CloseGameOver()
    {
        _gameOverScreen.SetActive(false);
    }
    
    
}
