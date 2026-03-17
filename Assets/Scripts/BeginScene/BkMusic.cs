using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BkMusic : MonoBehaviour
{
    private static BkMusic instance;
    public static BkMusic Instance => instance;
    private AudioSource bkSource;

    private void Awake()
    {
        instance = this;
        bkSource = GetComponent<AudioSource>();
        MusicData musicData = GameDataMgr.Instance.musicData;
        SetIsOpen(musicData.musicOpen);
        ChangeValue(musicData.musicvalue);
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetIsOpen(bool isOpen)
    {
        bkSource.mute = !isOpen;
    }

    public void ChangeValue(float v)
    {
        bkSource.volume = v;
    }
}
