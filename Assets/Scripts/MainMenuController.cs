using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void OnStartGamePressed()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void OnQuitPressed()
    {
#if UNITY_EDITOR
        // Editor mode
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Build mode
        Application.Quit();
#endif
    }
}
