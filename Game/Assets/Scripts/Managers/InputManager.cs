using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    public Action action;
    void Update()
    {
        if (GameManager.Instance.State == false) return;
      
        if (Input.anyKey == false)
        {
            return;
        }
        if (action != null)
        {
            action.Invoke();
        }
      
      
    }
}
