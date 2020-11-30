using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public List<AudioClip> sounds;
    public static AudioManager Instance { get; private set; }
    
    private List<AudioSource> _audioSources;

    private int _typingSources;

    private void Awake() {
        _audioSources = new List<AudioSource>();
        Instance = this;
    }

    public void PlaySound(string soundName, bool loop = false) {
        AudioSource source = GetAudioSource();

        AudioClip clip = null;

        for (int i = 0; i < sounds.Count; i++) {
            if (sounds[i].name == soundName) {
                clip = sounds[i];
            }
        }
        
        if(clip == null) return;

        source.clip = clip;
        source.loop = loop;
        source.volume = 1f;
        source.Play();
    }

    public void StopSound(string soundName, bool smoothFade = false) {
        for (int i = 0; i < _audioSources.Count; i++) {
            if (_audioSources[i].clip.name == soundName && _audioSources[i].isPlaying && Mathf.Approximately(_audioSources[i].volume, 1f)) {
                if (smoothFade) {
                    _audioSources[i].DOFade(0f, 0.05f).OnComplete(_audioSources[i].Stop).SetEase(Ease.Linear);
                }
                else {
                    _audioSources[i].Stop();
                }
                return;
            }
        }
    }

    public void PlayTyping() {
        if (_typingSources == 0) {
            PlaySound("typing", true);
        }
        
        _typingSources++;
    }

    public void StopTyping() {
        _typingSources--;

        if (_typingSources == 0) {
            StopSound("typing", true);
        }
    }

    private AudioSource GetAudioSource() {
        for (int i = 0; i < _audioSources.Count; i++) {
            if (!_audioSources[i].isPlaying) {
                return _audioSources[i];
            }
        }

        AudioSource newSource = gameObject.AddComponent<AudioSource>();
        newSource.playOnAwake = false;
        _audioSources.Add(newSource);
        return newSource;
    }
}

[Serializable]
public class StringAudioClipDictionary : SerializableDictionary<string, AudioClip> {
    
}
