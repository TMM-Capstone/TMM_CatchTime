using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadSampleScene()
    {
        SceneManager.LoadScene("TimerSetup");
    }
    public void LoadMain()
    {
        SceneManager.LoadScene("capstone_main");
    }
    public void LoadLogin()
    {
        SceneManager.LoadScene("Login");
    }
    public void LoadReport()
    {
        SceneManager.LoadScene("Report");
    }
    public void LoadShop()
    {
        SceneManager.LoadScene("Shop");
    }
    public void LoadFriendList()
    {
        SceneManager.LoadScene("FriendList");
    }
    public void LoadItemBag()
    {
        SceneManager.LoadScene("ItemBag");
    }
    public void LoadSettingScene()
    {
        SceneManager.LoadScene("SettingScene");
    }
    public void LoadFriendPlus()
    {
        SceneManager.LoadScene("FriendPlus");
    }
    public void LoadFriendAccept()
    {
        SceneManager.LoadScene("FriendAccept");
    }
    public void LoadFriendHouse()
    {
        SceneManager.LoadScene("FriendHouse");
    }
    public void LoadFriendReport()
    {
        SceneManager.LoadScene("FriendReport");
    }
    public void LoadGiveUpMain()
    {
        SceneManager.LoadScene("GiveUpMain");
    }
}