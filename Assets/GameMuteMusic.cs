using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMuteMusic : MonoBehaviour
{
    [SerializeField] private AudioSource _music, _clickSound;

    void Start()
    {
        if (!PlayerPrefs.HasKey("Music"))
        {
            _music.mute = false;
            PlayerPrefs.SetString("Music", "Yes");
        }

        if (!PlayerPrefs.HasKey("Sound"))
        {
            _clickSound.mute = false;
            PlayerPrefs.SetString("Sound", "Yes");

        }

        if (PlayerPrefs.GetString("Music") == "Yes")
        {
            _music.mute = false;
        }
        else
        {
            _music.mute = true;
        }

        if (PlayerPrefs.GetString("Sound") == "Yes")
        {
            _clickSound.mute = false;
        }
        else
        {
            _clickSound.mute = true;
        }
    }

    public void ClickSound()
    {
        _clickSound.Play();
    }

}
