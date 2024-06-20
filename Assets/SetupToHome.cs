using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetupToHome : MonoBehaviour
{
    public void LoadSampleScene()
    {
        SceneManager.LoadScene("capstone_main");
    }
}