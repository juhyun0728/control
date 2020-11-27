using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    private AudioSource audio;
    public AudioClip walk, jump, stick, menu_open, menu_close, gameStart, clear, gameover;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        this.audio = this.gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void play_walk()
    {
        if (this.audio.isPlaying == false)
        {
            this.audio.clip = this.walk;
            this.audio.Play();

        }
    }
    public void play_stick()
    {
        if (this.audio.isPlaying == false)
        {
            this.audio.clip = this.stick;
            this.audio.Play();

        }
    }
    public void play_menu_open()
    {
        if (this.audio.isPlaying == false)
        {
            this.audio.clip = this.menu_open;
            this.audio.Play();

        }
    }
    public void play_menu_close()
    {
        if (this.audio.isPlaying == false)
        {
            this.audio.clip = this.menu_close;
            this.audio.Play();

        }
    }
    public void play_gameStart()
    {
        if (this.audio.isPlaying == false)
        {
            this.audio.clip = this.gameStart;
            this.audio.Play();

        }
    }
    public void play_clear()
    {
        if (this.audio.isPlaying == false)
        {
            this.audio.clip = this.clear;
            this.audio.Play();

        }
    }
    public void play_gameover()
    {
        if (this.audio.isPlaying == false)
        {
            this.audio.clip = this.gameover;
            this.audio.Play();

        }
    }
}
