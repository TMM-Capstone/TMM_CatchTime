using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Clirgo.CasualUIPixelKit
{
    public class DemoToggle : MonoBehaviour
    {
        [SerializeField] Transform point;
        [SerializeField] float toggleLength = 0.5f;
        public void SwitchToggle(Toggle target)
        {
            if (target.isOn)
            {
                point.transform.Translate(Vector3.right * toggleLength);
            }
            else point.transform.Translate(Vector3.left * toggleLength);
        }
    }

}
