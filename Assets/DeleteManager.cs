using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteManager : MonoBehaviour
{
    [SerializeField] GameObject obj;

    public void DeleteObj()
    {
        Destroy(obj);
    }

}
