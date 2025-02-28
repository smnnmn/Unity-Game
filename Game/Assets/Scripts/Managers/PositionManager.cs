using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionManager : MonoBehaviour
{
    [SerializeField] float[] randomPositionZ = new float[16];
    [SerializeField] Transform[] parentRoads;
    [SerializeField] int index = -1;
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
        index = (index + 1) % parentRoads.Length;
        transform.SetParent(parentRoads[index]);
        transform.localPosition += new Vector3(0 ,0, 40);
    }
}
