using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    [SerializeField] List<GameObject> roads;
    [SerializeField] float speed;

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < roads.Count; i++)
        {
            roads[i].transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
    }
    public void InitializePosition()
    {
        GameObject NewRoad = roads[0];
        for(int i = 1; i < roads.Count; i++)
        {
            roads[i - 1] = roads[i];
        }
        roads[3] = NewRoad;
        NewRoad.transform.position = new Vector3(0, 0, 40 + roads[2].transform.position.z);
        
    }
}
