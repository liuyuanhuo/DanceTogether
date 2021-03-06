﻿using UnityEngine;
using UnityEngine.Audio;
using System.Collections;
using System;

public class AudioManagerScript : MonoBehaviour {
    
    public enum SFXClips
    {
        Correct,
        Wrong,
        RoundComplete,
        NewRound,
        Rules,
        DanceTogether,
        Countdown,
        Find
    };

    public AudioMixerSnapshot inMenu;
    public AudioMixerSnapshot inGameStarted;
    public AudioMixerSnapshot inGameplay;

    public AudioClip[] gameMusic;

    public AudioClip[] soundEffects;

    public AudioSource gameplaySource;
    public AudioSource menuSource;
    public AudioSource sfxSource;
    public float bpm = 120;

    private float m_TransitionIn;
    private float m_TransitionOut;
    private float m_QuarterNote;

    [HideInInspector]
    static public AudioManagerScript instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Use this for initialization
    void Start () {

        m_QuarterNote = 60 / bpm;
        m_TransitionIn = m_QuarterNote;
        m_TransitionOut = m_QuarterNote * 8;

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public int GetNumSongs()
    {
        return gameMusic.Length;
    }

    public static string GetSongName(int songID)
    {
        switch (songID)
        {
            case 0:
                return "Honky Tonk";
            case 1:
                return "Big Band";
            case 2:
                return "Drum & Bass";
            case 3:
                return "Congo";
            case 4:
                return "Dubstep";
            case 5:
                return "Hip Hop";
            case 6:
                return "Irish Jig";
            case 7:
                return "Mariachi";
            case 8:
                return "Metal";
            case 9:
                return "Polka";
            case 10:
                return "Salsa";
            case 11:
                return "Waltz";
            case 12:
                return "Tango";
            default: //Error
                return "!Error!";
        }
    }

    public void StartMenuMusic()
    {
        menuSource.Stop();
        menuSource.Play();
        inMenu.TransitionTo(m_TransitionIn);
    }

    public void EndGameMusic()
    {
        inGameStarted.TransitionTo(m_TransitionOut);
    }

    public void PrepareGameMusic()
    {
        inGameStarted.TransitionTo(m_TransitionOut);
    }

    public void StartGameMusic()
    {
        GameObject gm = GameObject.Find("LOCAL Player");
        gameplaySource.clip = gameMusic[gm.GetComponent<NetworkedPlayerScript>().GetSongID()];
        gameplaySource.Stop();
        gameplaySource.Play();
        inGameplay.TransitionTo(m_TransitionIn);
    }

    public void PlaySFX(SFXClips danceTogether)
    {
        PlaySFX(Convert.ToInt32(danceTogether));
    }

    private void PlaySFX(int i)
    {
        sfxSource.PlayOneShot(soundEffects[i]);
    }

    public void PlayRoundEnd(bool correct)
    {
        int sfx;
        if (correct) sfx = Convert.ToInt32(SFXClips.Correct);
        else sfx = Convert.ToInt32(SFXClips.Wrong);
        sfxSource.clip = soundEffects[sfx];
        sfxSource.Stop();
        sfxSource.PlayDelayed(1.5f);
        PlaySFX(SFXClips.RoundComplete);
    }

    public void PlayCountdown()
    {
        sfxSource.clip = soundEffects[Convert.ToInt32(SFXClips.Countdown)];
        sfxSource.Stop();
        sfxSource.PlayDelayed(1f);
        PlaySFX(SFXClips.NewRound);
    }

    public void PlayRules()
    {
        sfxSource.clip = soundEffects[Convert.ToInt32(SFXClips.Rules)];
        sfxSource.Stop();
        sfxSource.Play();
    }

    public void PlayFind()
    {
        sfxSource.clip = soundEffects[Convert.ToInt32(SFXClips.Find)];
        sfxSource.Stop();
        sfxSource.Play();
    }

    public void StopSFX()
    {
        sfxSource.Stop();
    }
}
