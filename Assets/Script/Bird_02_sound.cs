using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_02_sound : MonoBehaviour, ICatalog
{

    public AudioClip[] birdSound;
    AudioSource birdAudio;

    void Awake()
    {
        birdAudio = gameObject.GetComponent<AudioSource>();
    }

    void Start()
    {
        gameObject.SetActive(false);

        CountDownTimer.GetInstance().CountDown(Random.Range(1,100), () =>
        {
            gameObject.SetActive(true);
        });
    }

    void ICatalog.ShowCatalog(Object caller)
    {
        Debug.Log("gigigigi");
        birdAudio.clip = birdSound[Random.Range(0,1)];
        birdAudio.volume = 0.1f;
        birdAudio.Play();
        Invoke("SoundFinish", birdAudio.clip.length);

        CountDownTimer.GetInstance().CountDown(Random.Range(80, 1000), () =>
        {
            gameObject.SetActive(true);
        });
    }

    void SoundFinish()
    {
        gameObject.SetActive(false);
    }
}
