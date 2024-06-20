using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpTrigger : MonoBehaviour
{
    public void OnClickTrigger()
    {
        PopUpManager.Instance.Open(
           OnClickConformButton: () =>
           {
               Debug.Log("On Trigger Conform Button");
           });
    }
}
