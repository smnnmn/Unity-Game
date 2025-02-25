using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] List<GameObject> obstacles = new List<GameObject>();
    [SerializeField] List<GameObject> randomObject = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 5; i++)
        {
            randomObject.Add(obstacles[Random.Range(0, obstacles.Count)]);
        }
        for(int i = 0; i < randomObject.Count; i++)
        {
            Instantiate(randomObject[i]);
            randomObject[i].gameObject.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
