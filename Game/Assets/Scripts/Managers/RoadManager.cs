using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    [SerializeField] List<GameObject> roads;
    [SerializeField] float speed;
    [SerializeField] float offset = 40.0f;

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < roads.Count; i++)
        {
            roads[i].transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
    }
    public void InitializePosition()
    {
        GameObject newRoad = roads[0];

        roads.Remove(newRoad);
        newRoad.transform.position = new Vector3(0, 0, offset + roads[2].transform.position.z);
        roads.Add(newRoad);
    }
}
