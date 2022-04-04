using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.Video;
 using UnityEngine.SceneManagement;

public class videoEnd : MonoBehaviour
{
    public VideoPlayer VideoPlayer;
    public VideoPlayer VideoPlayer2;
    public string SceneName ;


    void Start() 
    {
          VideoPlayer.loopPointReached += PlaySecond;
          VideoPlayer2.loopPointReached += LoadScene;
    }

    void LoadScene(VideoPlayer vp2)
    {
          SceneManager.LoadScene( SceneName );
    }

    void PlaySecond(VideoPlayer vp)
    {
          VideoPlayer2.Play();
    }
}
