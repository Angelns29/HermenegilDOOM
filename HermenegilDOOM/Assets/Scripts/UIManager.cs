using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [Header("Start")]
    public GameObject startMenu;
    [Header("Settings")]
    public GameObject settingsMenu;
    public Slider musicSlider;
    public Slider sfxSlider;
    public AudioSource musicSource;
    public AudioSource sfxSource;
    
    [Header("HUD")]
    public GameObject hud;
    public TMP_Text bulletText;
    //public AgentWeapon Weapon;
    public Slider healthSlider;
    private PlayerMovement player;
    [Header("Pause")]
    public GameObject pauseMenu;
    public GameObject pauseButton;
    [Header("Die")]
    public GameObject dieMenu;
    [Header("GameOver")]
    public GameObject gameOverMenu;
    private AudioManager _audioManager;
    // Start is called before the first frame update
    void Start()
    {
        _audioManager = AudioManager.instance;
        player = GameObject.Find("PlayerV2").GetComponent<PlayerMovement>();
        musicSlider.value = musicSource.volume;
        sfxSlider.value = sfxSource.volume;
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        SetBullets();
    }
    public void DisableStart()
    {
        startMenu.SetActive(false);
        pauseButton.SetActive(true);
        hud.SetActive(true);
        Time.timeScale = 1f;
        _audioManager.StartMusic();
    }
    public void ExitGame()
    {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif

    }
    public void ReturnMenu()
    {
        settingsMenu.SetActive(false);
        startMenu.SetActive(true);
    }
    public void ShowPauseMenu()
    {
        pauseButton.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        pauseButton.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void ReturnFromPause()
    {
        pauseMenu.SetActive(false);
        hud.SetActive(false);
        startMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void PlayAgain()
    {
        gameOverMenu.SetActive(false);
        hud.SetActive(true);
        SceneManager.LoadScene(0);
    }
    public void SetBullets()
    {
        bulletText.text = "5"; //Weapon.Qbullet.ToString();
    }
    public void SetGameOver()
    {
        hud.SetActive(false);
        gameOverMenu.SetActive(true);
    }
    public void SetHeath()
    {
        healthSlider.value = player.health;
    }
    #region die
    public void Die()
    {
        hud.SetActive(false);
        dieMenu.SetActive(true);
    }
    public void Restart()
    {
        Scene actualScene = SceneManager.GetActiveScene();
        dieMenu.SetActive(false);
        hud.SetActive(true);
        player.health = 100;
        player.SetPlayer();
        ResetHealth();
        SceneManager.LoadScene(actualScene.name);
    }

    public void ResetHealth()
    {
        healthSlider.value = 100;
    }

    public void ReturnFromDie()
    {
        dieMenu.SetActive(false);
        hud.SetActive(false);
        startMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    #endregion
    #region settings
    public void ChangeToSettings()
    {
        startMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }
    public void ChangeToSettingsFromPause()
    {
        //pauseMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }
    public void SetVolume(float volume)
    {
        musicSource.volume = volume;
    }
    public void SetVolumeSounds(float volume)
    {
        sfxSource.volume = volume;
    }
    #endregion
}
