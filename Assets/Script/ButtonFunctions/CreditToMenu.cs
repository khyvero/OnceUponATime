using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CreditToMenu : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    private void Start()
    {
        videoPlayer.loopPointReached += LoadScene;
    }

    public void LoadScene(UnityEngine.Video.VideoPlayer vp)
    {
        Debug.Log("Video is finish, loading next scene");

        Object.FindObjectOfType<GameStateApplied>().gameState.SwitchToMenu();
    }
}
