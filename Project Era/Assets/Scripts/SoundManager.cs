using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    public AudioSource musicSource;
    public AudioSource battleMusicSource;
    public AudioSource sfxSource;
    public static SoundManager instance = null;

    public float lowPitchRange = 0.95f;
    public float highPitchRange = 1.05f;

    public AudioClip junglesOfLongAgo;
    public AudioClip meleeToRemember;


    // Use this for initialization
    void Awake () {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        SoundManager.instance.PlaySong(junglesOfLongAgo);
	
	}
	
	// Update is called once per frame
	void Update () {

        if (BattleTime.engageEnemy == true)
        {
            SoundManager.instance.PauseSong(junglesOfLongAgo);
            SoundManager.instance.PlayBattleSong(meleeToRemember);
        }
        

        else if (BattleTime.victoryAnimation == true && BattleTime.timer == 390)
        {
            SoundManager.instance.UnPauseSong(junglesOfLongAgo);
        }

	}




    public void PlaySong (AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void PauseSong(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Pause();
    }

    public void UnPauseSong(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.UnPause();
    }


    public void PlayBattleSong(AudioClip clip)
    {
        battleMusicSource.clip = clip;
        battleMusicSource.Play();
    }

    public void PlaySoundEffect(AudioClip clip)
    {
        sfxSource.clip = clip;
        sfxSource.Play();

    }


    public void RandomizeSFX(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);

        sfxSource.pitch = randomPitch;
        sfxSource.clip = clips[randomIndex];
        sfxSource.Play();



    }

}
