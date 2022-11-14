using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuOptions : MonoBehaviour
{
    [Header("Audio")]
    public AudioMixer audioMixer;

    //[Header("MouseSens")]
    //public Look mouseSens;

    public TMP_Dropdown resolutionDropDown;
    Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropDown.ClearOptions();

        int currtentRes = 0;
        List<string> options = new List<string>();
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currtentRes = i;
            }
        }

        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currtentRes;
        resolutionDropDown.RefreshShownValue();
    }
    public void SetVolume(float volume) 
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void SetSens(float sens) 
    {
    
    }

    public void SetFullScreen(bool FullScreen) 
    {
        Screen.fullScreen = FullScreen;
    }

    public void SetResolution(int resolutionIndex) 
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height,Screen.fullScreen);
    }
}
