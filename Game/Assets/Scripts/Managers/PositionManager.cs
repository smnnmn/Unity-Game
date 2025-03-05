using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionManager : MonoBehaviour
{
    [SerializeField] Coroutine coroutine;

    [SerializeField] float[] randomPositionZ = new float[16];
    [SerializeField] Transform[] parentRoads;
    [SerializeField] int index = -1;
    [SerializeField] Transform[] positionRandomX;

    [SerializeField] ObstacleManager obstacleManager;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 16; i++)
        {
            randomPositionZ[i] = i * 2.5f + -10.0f;
        }
    }

    public void InitializePosition()
    {
        if(coroutine == null)
        {
            coroutine = StartCoroutine(SetPosition());
        }
        index = (index + 1) % parentRoads.Length;
        transform.SetParent(parentRoads[index]);
        transform.localPosition += new Vector3(0 ,0, 40);
    }

    public IEnumerator SetPosition()
    {
        while(GameManager.Instance.State)
        {
            yield return CoroutineCache.WaitForSecond(2.5f);

            transform.localPosition = new Vector3(0, 0, randomPositionZ[Random.Range(0,randomPositionZ.Length)]);

            obstacleManager.GetObstacle().SetActive(true);

            obstacleManager.GetObstacle().transform.position = positionRandomX[Random.Range(0,positionRandomX.Length)].position;

            obstacleManager.GetObstacle().transform.SetParent(transform.root.GetChild(index));


            // GameObject prefab = obstacleManager.GetObstacle();
            // prefab.transform.SetParent(parentRoads[index]);
            // 
            // prefab.transform.localPosition = new Vector3(positionRandomX[Random.Range(0, positionRandomX.Length - 1)].position.x,
            //     0,
            //     randomPositionZ[Random.Range(0, randomPositionZ.Length - 1)]);
            // yield return null;
        }
       
    }
}   
