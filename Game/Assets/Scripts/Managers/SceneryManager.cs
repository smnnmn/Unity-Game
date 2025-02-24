using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneryManager : Singleton<SceneryManager>
{
    [SerializeField] Image screenImage;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

    }

    public IEnumerator AsyncLoad(int index)
    {
        screenImage.gameObject.SetActive(true);

        // <asyncOperation.allowSceneActivation>
        // ����� �غ�� ��� ����� Ȱ��ȭ�Ǵ� ���� ����ϴ� �����Դϴ�.
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(index);

        asyncOperation.allowSceneActivation = false;

        Color color = screenImage.color;

        // <asyncOperation.isDone>
        // �ش� ������ �Ϸ�Ǿ����� ��Ÿ���� �����Դϴ�.
        while(asyncOperation.isDone == false)
        {
            color.a += Time.deltaTime;

            screenImage.color = color;

            // <asyncOperation.progress>
            // �۾��� ���� ���¸� ��Ÿ���� �����Դϴ�.
            if(asyncOperation.progress >= 0.9f)
            {
                color.a = Mathf.Lerp(color.a, 1f, Time.deltaTime);
                screenImage.color = color;

                if(color.a >= 1.0f)
                {
                    asyncOperation.allowSceneActivation = true;

                    yield break;
                }
            }

            yield return null;
        }
        

    }

    void OnSceneLoaded(Scene scene,LoadSceneMode loadSceneMode)
    {
        StartCoroutine(FadeIn());
    }

    public IEnumerator FadeIn()
    {
        Color color = screenImage.color;

        color.a = 1f;

        screenImage.gameObject.SetActive(true);

        while (color.a >= 0.0f)
        {
            color.a -= Time.deltaTime;
            screenImage.color = color;
            yield return null;
        }
        screenImage.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

}
