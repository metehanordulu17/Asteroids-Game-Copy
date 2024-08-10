using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] List<AudioSource> crashSounds;
    private bool IsPlaying = false;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsPlaying)
        {
            StartCoroutine(PlayBackgroundMusic());
        }
    }
    public void OnCrashPlaySound(int index)
    {
        crashSounds[index].Play();
    }
    IEnumerator PlayBackgroundMusic()
    {
        IsPlaying = true;
        crashSounds[3].Play();
        yield return new WaitForSeconds(1.5f);
        IsPlaying = false;
    }
}
