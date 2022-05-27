using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class LoadScene : MonoBehaviour
{
    public Button[] lvls;
    public Slider musicSlider, soundSlider;

    public void Start()
    {
        if (PlayerPrefs.HasKey("Lvl"))
            for (int i = 0; i < lvls.Length; i++)
                lvls[i].interactable = (i*2) <= PlayerPrefs.GetInt("Lvl");
        if (!PlayerPrefs.HasKey(nameof(musicSlider)))
            PlayerPrefs.SetInt(nameof(musicSlider), 3);
        if (!PlayerPrefs.HasKey(nameof(soundSlider)))
            PlayerPrefs.SetInt(nameof(soundSlider), 3);
        musicSlider.value = PlayerPrefs.GetFloat(nameof(musicSlider));
        soundSlider.value = PlayerPrefs.GetFloat(nameof(soundSlider));
    }

    private void Update()
    {
        PlayerPrefs.SetFloat(nameof(musicSlider), musicSlider.value);
        PlayerPrefs.SetFloat(nameof(soundSlider), soundSlider.value);
    }


    public void DeleteKeys() => PlayerPrefs.DeleteAll();
    public void Load(int sceneNumber) => SceneManager.LoadScene(sceneNumber);

    public void ExitGame() => Application.Quit();
}
