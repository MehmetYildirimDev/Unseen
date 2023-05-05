using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicVolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;


    private void Start()
    {
        //hata burada
        float volume = PlayerPrefs.GetFloat("musicSource");

        slider.value = volume;

        SoundManager.instance.ChangeMusicVolume(slider.value);
        slider.onValueChanged.AddListener(value => SoundManager.instance.ChangeMusicVolume(value));
    }


}
