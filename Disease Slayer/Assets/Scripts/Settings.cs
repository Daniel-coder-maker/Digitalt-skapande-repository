using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class Settings : MonoBehaviour
{
    public float brightness;
    public AudioMixer audiomixer;
    public AudioMixer musicmixer;
    public AudioMixer soundmixer;
    public AudioMixer voicemixer;

    public TMP_Dropdown resolutionDropdown;
    Resolution[] resolutions;


    void Start()
    {
      resolutions =  Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i< resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.width && resolutions[i].height==Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

            resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetVolume(float volume)
    {
        audiomixer.SetFloat("Volume", Mathf.Log10(volume)*20);
    }

    public void SetMusic(float volumeM)
    {
        musicmixer.SetFloat("VolumeM", Mathf.Log10(volumeM) * 20);
    }

    public void SetSound(float volumeS)
    {
        soundmixer.SetFloat("VolumeS", Mathf.Log10(volumeS) * 20);
    }

    public void SetVoice(float volumeV)
    {
        voicemixer.SetFloat("VolumeV", Mathf.Log10(volumeV) * 20);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void UpdateLight(float GammaCorrection)
    {
        Screen.brightness = GammaCorrection;
    }

    public void SaveDatan()
    {
        Saving.SavedSettings(this);
    }

    public void LoadDatan()
    {
       SaveData data = Saving.LoadData();
        brightness = data.brightness;
        //audiomixer = data.audiomixer;
    }
}
