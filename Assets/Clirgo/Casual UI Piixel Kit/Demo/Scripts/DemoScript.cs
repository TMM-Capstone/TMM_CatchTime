using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Clirgo.CasualUIPixelKit
{

    public class DemoScript : MonoBehaviour
    {
        public List<GameObject> uiElements;
        public Transform canvas;
        public TextMeshProUGUI count;

        private int currentIndex = 0;
        private GameObject currentUI;


        private void Start()
        {
            ShowUI(currentIndex);
        }

        public void NextUI()
        {
            currentIndex++;

            if (currentIndex >= uiElements.Count) currentIndex = 0;

            ShowUI(currentIndex);
        }

        public void PrevUI()
        {
            currentIndex--;

            if (currentIndex < 0) currentIndex = uiElements.Count - 1;

            ShowUI(currentIndex);
        }

        private void ShowUI(int currentIndex)
        {
            if (currentIndex < uiElements.Count)
            {
                if (currentUI != null) ClearUI();
                currentUI = Instantiate(uiElements[currentIndex], canvas);
                string modifiedString = currentUI.name.Replace("(Clone)", "");
                count.text = modifiedString;
            }
        }

        public void ClearUI()
        {
            Destroy(currentUI);
            currentUI = null;
            Canvas.ForceUpdateCanvases();
        }

    }
}