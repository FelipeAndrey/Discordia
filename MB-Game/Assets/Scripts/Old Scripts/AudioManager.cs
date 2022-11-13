using System;
using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    private void Start()
    {

    }

    public void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.AudioSource = gameObject.AddComponent<AudioSource>();
            s.AudioSource.clip = s.Clip;
            s.AudioSource.volume = s.Volume;
            s.AudioSource.pitch = s.Pitch;
            s.AudioSource.loop = s.Loop;
            s.AudioSource.outputAudioMixerGroup = s.output;
        }
    }

    IEnumerator WaterDrop()
    {
        while (true)
        {
            Play("WaterDrop");
            yield return new WaitForSeconds(16f);
        }
    }

    #region Audio Settings Methods
    public void Play(string Name)
    {

        Sound s = Array.Find(sounds, sound => sound.Name == Name);
        if (s == null)
            return;
        s.AudioSource.Play();
        //s.AudioSource.PlayOneShot(s.AudioSource.clip);
    }
    public void Stop(string Name)
    {
        Sound s = Array.Find(sounds, sound => sound.Name == Name);
        if (s == null)
            return;
        s.AudioSource.Stop();
    }
    public void Pitch(string Name, float value)
    {
        Sound s = Array.Find(sounds, sound => sound.Name == Name);
        if (s == null)
            return;
        s.AudioSource.pitch = value;
    }
    public void Volume(string Name, float value)
    {
        Sound s = Array.Find(sounds, sound => sound.Name == Name);
        if (s == null)
            return;
        s.AudioSource.volume = value;
    }
    #endregion
}
