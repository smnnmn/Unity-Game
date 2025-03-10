using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeManager : Singleton<TimeManager>
{
    [SerializeField] float activeTime;
    [SerializeField] float increaseTime;
    public float ActiveTime
    {
        get { return activeTime; }
    }
    public float IncreaseTime
    {
        get { return increaseTime; }
    }
    protected override void Awake()
    {
        base.Awake();
        activeTime = 2.5f;
        increaseTime = 2.5f;
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

    }
    IEnumerator Decrease()
    {
        while(GameManager.Instance.State && activeTime > 0.25f)
        {
            yield return CoroutineCache.WaitForSecond(4f);
            activeTime -= 0.25f;
        }
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        StartCoroutine(Decrease());
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

}
