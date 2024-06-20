using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeToSetting : MonoBehaviour
{
    public void LoadSampleScene()
    {
        SceneManager.LoadScene("SettingScene");
    }
}