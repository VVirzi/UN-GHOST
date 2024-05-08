using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class Button_Manager : MonoBehaviour
{
    public void ChangeToTutorialScene()
    {
        SceneManager.LoadScene("IntroductionLevel");
    }
    public void ChangeToInitialMenuScene()
    {
        SceneManager.LoadScene("InitialMenu");
    }
    public void ChangeToPrincipalLevelScene()
    {
        SceneManager.LoadScene("PortalLevel");
    }
    public void ChangeToVictiryScene()
    {
        SceneManager.LoadScene("VictoryMenu");
    }
    public void ChangeToDefeatScene()
    {
        SceneManager.LoadScene("DefeatMenu");
    }
    public void ExitGameButton()
    {
        Application.Quit();
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
    }
}
