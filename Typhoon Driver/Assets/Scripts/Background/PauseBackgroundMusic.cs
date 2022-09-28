using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseBackgroundMusic : MonoBehaviour
{
    private void Start()
    {
        BackgroundMusic.instance.gameObject.GetComponent<AudioSource>().Pause();
    }
}
