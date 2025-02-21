using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Execute()
    {
        StartCoroutine(SceneryManager.Instance.AsyncLoad(1));
    }

    public void Quit()
    {
        Debug.Log("게임 종료");
    }
}
