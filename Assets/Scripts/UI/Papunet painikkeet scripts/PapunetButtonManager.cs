using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PapunetButtonManager : MonoBehaviour
{
    public ListenButton listenButton;
    public bool fetchIfSoundIsOn;

    private void Update()
    {
        //fetchIfSoundIsOn = listenButton.GetComponent<ListenButton>().soundOn;

        SoundOn();
    }

    public void SoundOn()
    {

    }
}
