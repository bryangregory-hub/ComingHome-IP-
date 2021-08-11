using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    // Update is called once per frame
    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        save();
    }
    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicvolume");
    }

    private void save()
    {
        PlayerPrefs.SetFloat("musicvolume", volumeSlider.value);
    }
}
