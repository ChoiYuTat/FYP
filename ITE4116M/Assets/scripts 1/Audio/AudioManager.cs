using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private AudioSource bgm;
    private void Awake()
    {
        Instance = this;
    }

    public void Init()
    {
        bgm = gameObject.AddComponent<AudioSource>();
    }

    public void PlayBGM(string name, bool isLoop = true)
    {
        AudioClip clip = Resources.Load<AudioClip>("Sounds/BGM/" + name);

        bgm.clip = clip;

        bgm.loop = isLoop;

        bgm.Play();
    }

    public void PlayEffect(string name)
    {
        AudioClip clip = Resources.Load<AudioClip>("Sounds/" + name);

        AudioSource.PlayClipAtPoint(clip, transform.position);

    }
}
