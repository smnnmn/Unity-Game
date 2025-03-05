using System.Collections;
using System.Collections.Generic;
using Unity.Jobs;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] int random;
    [SerializeField] int createCount = 5;
    [SerializeField] List<GameObject> obstacles;
    [SerializeField] List<string> obstacleNames;
    [SerializeField] PositionManager positionManager;
    // Start is called before the first frame update
    void Start()
    {

        Create();
        StartCoroutine(ActiveObstacle());
    }
    public void Create()
    {
        obstacles.Capacity = 10;

        for (int i = 0; i < createCount; i++)
        {
            GameObject prefab = ResourcesManager.Instance.Instantiate(obstacleNames[Random.Range(0, obstacleNames.Count)]) ;

            prefab.SetActive(false); 

            obstacles.Add(prefab);
        }
    }


    public bool ExamineActive()
    {
        for (int i = 0; i < obstacles.Count; i++)
        {
            if (obstacles[i].activeSelf == false)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator ActiveObstacle()
    {
        while(GameManager.Instance.State)
        {
            yield return CoroutineCache.WaitForSecond(2.5f);

            random = Random.Range(0, obstacles.Count);
            // ���� ���� ������Ʈ�� Ȱ��ȭ�Ǿ� �ִ� �� Ȯ���մϴ�.
            while (obstacles[random].activeSelf == true)
            {
                // ���� ����Ʈ�� �ִ� ��� ���� ������Ʈ�� Ȱ��ȭ�Ǿ� �ִ� �� Ȯ���մϴ�.
                if(ExamineActive())
                {
                    // ��� ���� ������Ʈ�� Ȱ��ȭ�Ǿ� �ִٸ� ���� ������Ʈ�� ����
                    // ������ ���� obstacles ����Ʈ�� �־��ݴϴ�.

                    for (int i = 0; i < 1; i++)
                    {
                        GameObject prefab = ResourcesManager.Instance.Instantiate(obstacleNames[Random.Range(0, obstacleNames.Count)]);
                    
                        prefab.SetActive(false);
                    
                        obstacles.Add(prefab);


                    }
                }
                // ���� �ε����� �ִ� ���� ������Ʈ�� Ȱ��ȭ �Ǿ� ������
                // random ������ ���� +1�� �ؼ� �ٽ� �˻��մϴ�.
                random = (random + 1) % obstacles.Count;
            }

            // StartCoroutine(positionManager.SetPosition());

            // �������� ������ Obstacle ������Ʈ�� Ȱ��ȭ�մϴ�.
            // obstacles[random].SetActive(true);

        }

    }
    public GameObject GetObstacle()
    {
        return obstacles[random] ;
    }
}
