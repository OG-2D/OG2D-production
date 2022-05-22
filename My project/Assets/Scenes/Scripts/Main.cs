using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public PlayerScript1 player;
    public Image[] hearts;
    public Sprite isLife, isDead;
    public GameObject PauseScreen;
    public void Lose() =>SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    public void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
           hearts[i].sprite = player.GetHearts() > i ? isLife : isDead;
        }
    }

    public void PauseOn()
    {
        Time.timeScale = 0f;
        player.enabled = false;
        PauseScreen.SetActive(true);
    }

    public void PauseOff()
    {
        Time.timeScale = 1f;
        player.enabled = true;
        PauseScreen.SetActive(false);
    }

    public void Load(int level)
    {
        Lose();
        PauseOff();
        SceneManager.LoadScene(level);
    }
}
