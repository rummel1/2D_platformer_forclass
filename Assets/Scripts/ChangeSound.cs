using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSound : MonoBehaviour
{
    [SerializeField] private Slider _soundSlider;
    [SerializeField] private Slider _musicSlider;
    private SoundManager _soundManager;
    private AudioSource _musicSource;
    private AudioSource _soundSource;
    void Start()
    { 
        _soundManager = FindObjectOfType<SoundManager>();
        _soundSource = _soundManager.GetComponent<AudioSource>();
        _musicSource = _soundManager.transform.GetChild(0).GetComponent<AudioSource>();
        
    }

    private void Update()
    {
        ChangeVolume();
    }

    // Update is called once per frame
    public void ChangeVolume()
    {
        _soundSource.volume = _soundSlider.value;
        _musicSource.volume = _musicSlider.value;
    }
}
