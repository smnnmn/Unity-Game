using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    [SerializeField] List<GameObject> roads;
    [SerializeField] float offset = 40.0f;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.State == false) return;

        for (int i = 0; i < roads.Count; i++)
        {
            roads[i].transform.Translate(Vector3.back * SpeedManager.Speed * Time.deltaTime);
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
