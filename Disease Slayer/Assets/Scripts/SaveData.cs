using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SaveData
{
    public float brightness;
    public bool audiomixer;
    public bool musicmixer;
    public bool soundmixer;
    public bool voicemixer;

    public SaveData(Settings settings)
    {
        brightness = settings.brightness;
        audiomixer = settings.audiomixer;
        musicmixer = settings.musicmixer;
        soundmixer = settings.soundmixer;
        voicemixer = settings.soundmixer;
    }
}
