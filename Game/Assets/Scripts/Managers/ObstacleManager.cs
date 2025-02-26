using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] int createCount = 5;
    [SerializeField] List<GameObject> obstacles;
    [SerializeField] List<string> obstacleNames;
    // Start is called before the first frame update
    void Start()
    {
        Create();
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

}
