using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    void Start()
    {
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            PlayerPrefs.SetFloat("MusicVolume", 1);
            load();
        }
        else
        {
            load();
        }
    }
    public void changeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        save();
    }

    private void load()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("MusicVolume");
    }

    private void save()
    {
        PlayerPrefs.SetFloat("MusicVolume", volumeSlider.value);
    }
}
