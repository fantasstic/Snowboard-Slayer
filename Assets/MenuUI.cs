using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private AudioSource _music, _clickSound;
    [SerializeField] private Text _scoreText;
    [SerializeField] private Image _musicImage, _soundImage;
    [SerializeField] private Sprite _offMusic, _onMusic, _offSound, _onSound;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private GameObject _settings;

    private void Start()
    {
        _scoreText.text = PlayerPrefs.GetInt("BestScore").ToString();

        if(!PlayerPrefs.HasKey("Music"))
        {
            _music.mute = false;
            _musicImage.sprite = _onMusic;
            PlayerPrefs.SetString("Music", "Yes");
        }

        if (!PlayerPrefs.HasKey("Sound"))
        {
            _clickSound.mute = false;
            _soundImage.sprite = _onMusic;
            PlayerPrefs.SetString("Sound", "Yes");

        }

        if (PlayerPrefs.GetString("Music") == "Yes")
        {
            _music.mute = false;
            /*PlayerPrefs.SetString("Music", "Yes");*/
            _musicImage.sprite = _onMusic;
        }
        else
        {
            _music.mute = true;
            _musicImage.sprite = _offMusic;
        }

        if (PlayerPrefs.GetString("Sound") == "Yes")
        {
            _clickSound.mute = false;
            _soundImage.sprite = _onMusic;
        }
        else
        {
            _clickSound.mute = true;
            _soundImage.sprite = _offMusic;
        }
    }

    public void MusicSwitch()
    {
        SoundClick();
        if (PlayerPrefs.GetString("Music") == "No")
        {
            _music.mute = false;
            PlayerPrefs.SetString("Music", "Yes");
            _musicImage.sprite = _onMusic;
        }
        else
        {
            _music.mute = true;
            PlayerPrefs.SetString("Music", "No");
            _musicImage.sprite = _offMusic;
        }
    }

    public void SoundSwitch()
    {
        SoundClick();
        if (PlayerPrefs.GetString("Sound") == "No")
        {
            _clickSound.mute = false;
            PlayerPrefs.SetString("Sound", "Yes");
            _soundImage.sprite = _onMusic;
        }
        else
        {
            _clickSound.mute = true;
            PlayerPrefs.SetString("Sound", "No");
            _soundImage.sprite = _offMusic;
        }
    }

    public void Settings()
    {
        SoundClick();
        if(_settings.active)
        {
            _settings.SetActive(false);
            _canvas.sortingOrder = 0;
        }
        else
        {
            _canvas.sortingOrder = 2;
            _settings.SetActive(true);
        }
    }

    public void SoundClick()
    {
        _clickSound.Play();
    }
}
