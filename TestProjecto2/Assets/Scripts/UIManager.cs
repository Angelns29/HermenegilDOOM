using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Start")]
    [SerializeField] public GameObject startMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void DisableStart()
    {
        startMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void ExitGame()
    {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif

    }
}
