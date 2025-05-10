using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip[] soundClips;
    [SerializeField] private AudioSource audioSource;
    [SerializeField][Range(0f, 1f)] private float volumeVariation = 0.1f;
    [SerializeField][Range(0f, 2f)] private float pitchVariation = 0.1f;
    // Start is called before the first frame update
    private void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    public void PlayRandomSound()
    {
        if (soundClips.Length == 0 || audioSource == null)
        {
           
            return;
        }

        
        int randomIndex = Random.Range(0, soundClips.Length);
        AudioClip selectedClip = soundClips[randomIndex];

        
        audioSource.volume = Random.Range(1 - volumeVariation, 1 + volumeVariation);
        audioSource.pitch = Random.Range(1 - pitchVariation, 1 + pitchVariation);

        
        audioSource.PlayOneShot(selectedClip);
    }
}
