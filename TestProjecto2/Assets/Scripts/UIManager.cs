using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
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
    public AgentWeapon Weapon;
    [Header("Pause")]
    public GameObject pauseMenu;
    public GameObject pauseButton;
    [Header("Die")]
    public GameObject dieMenu;

    private AudioManager _audioManager;
    // Start is called before the first frame update
    void Start()
    {
        _audioManager = AudioManager.instance;
        musicSlider.value = musicSource.volume;
        sfxSlider.value = sfxSource.volume;
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

    public void SetBullets()
    {
        bulletText.text = Weapon.Qbullet.ToString();
    }
    #region die
    public void Restart()
    {
        Scene actualScene = SceneManager.GetActiveScene();
        dieMenu.SetActive(false);
        SceneManager.LoadScene(actualScene.name);
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
