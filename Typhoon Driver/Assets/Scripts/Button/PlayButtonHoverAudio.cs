using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonHoverAudio : MonoBehaviour
{
    public GameObject buttonHoverAudio;

    public void DropAudio()
    {
        Instantiate(buttonHoverAudio, transform.position, transform.rotation);
    }
}
