using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;


    [Header("Music")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioClip level1Music;
    [SerializeField] private AudioClip level2Music;
    [Header("Sound Effects")]
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip playerShoot;
    [SerializeField] private AudioClip playerDestroy;
    [SerializeField] private AudioClip enemyDestroy;
    [SerializeField] private AudioClip[] enemyShoot;





    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(string sound)
    {
        switch (sound)
        {
            case "PlayerShoot":
                source.PlayOneShot(playerShoot);
                break;
            case "EnemyShoot":
                int index = Random.Range(0, enemyShoot.Length);
                source.PlayOneShot(enemyShoot[index]);
                break;
            case "PlayerDestroy":
                source.PlayOneShot(playerDestroy);
                break;
            case "EnemyDestroy":
                source.PlayOneShot(enemyDestroy);
                break;
            default:
                Debug.LogWarning("Sound not found: " + sound);
                break;
        }
    }

    public void MusicTwoLevel()
    {
        musicSource.clip = level2Music;
        musicSource.Play();
    }

}
