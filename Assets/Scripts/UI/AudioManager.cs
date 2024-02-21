using System.Collections.Generic;
using UnityEngine;

public enum SoundType
{
    click,
    highlited,
    theme
}

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip themeClip;
    [SerializeField] private AudioClip clickClip;
    [SerializeField] private AudioClip highlitedClip;
    private List<AudioSource> _soundSources;
    private GameObject _sourcesHolder;

    // clip volume , looped додати
    public void PlaySound(SoundType soundType)
    {
        bool playedFlag = false;

        foreach (AudioSource source in _soundSources)
        {
            if (!source.isPlaying)
            {
                playedFlag = true;
                source.clip = ChooseClip(soundType);
                source.Play();
                break;
            }
        }
        if (!playedFlag)
        {
            CreateNewSource();
            PlaySound(soundType);
        }

    }

    private void Start()
    {
        _soundSources = new List<AudioSource>();
        _sourcesHolder = new GameObject("AudioSourcesHolder");
        _sourcesHolder.transform.parent = this.transform;
        PlaySound(SoundType.theme);
    }

    private AudioClip ChooseClip(SoundType soundType)
    {
        switch (soundType)
        {
            case SoundType.click:
                return clickClip;
            case SoundType.highlited:
                return highlitedClip;
            case SoundType.theme:
                return themeClip;
        }
        return null;
    }

    private void CreateNewSource()
    {
        GameObject newSource = new GameObject("AudioSource" + _soundSources.Count);
        newSource.transform.parent = _sourcesHolder.transform;
        _soundSources.Add(newSource.AddComponent<AudioSource>());
    }
}