using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna;

public class SoundManager : AttributesSync
{
    public static SoundManager Instance;
    AudioSource player;
    public AudioClip[] sounds;
    [SynchronizableField] public bool hit;
    [SynchronizableField] public bool death;
    [SynchronizableField] public bool ok;

    void Awake()
    {
        if(Instance != this && Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(this);
    }
    void Start()
    {
        player = GetComponent<AudioSource>();
    }
    void Update()
    {
        if(hit)
        {
            player.clip = sounds[0];
            player.Play();
            hit = false;
        }
        if(death)
        {
            player.clip = sounds[1];
            player.Play();
            death = false;
        }
        if(ok)
        {
            player.clip = sounds[2];
            player.Play();
            ok = false;
        }
    }
    public void Sound(int sound)
    {
        if (sound == 0) hit = true;
    }

}
