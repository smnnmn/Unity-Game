using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] Text textTime;
    [SerializeField] int minute;
    [SerializeField] int second;
    [SerializeField] int milliseconds;

    [SerializeField] float time;
    private void Awake()
    {
        
        textTime = GetComponent<Text>();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Watch());
    }

    // Update is called once per frame
    void Update()
    {
       
      
        // textTime.text = string.Format("{0:N2}", time);
    }
    IEnumerator Watch()
    {
        while(GameManager.Instance.State)
        {
            time += Time.deltaTime;

            minute = (int)time / 60;
            second = (int)time % 60;
            milliseconds = (int)(time * 100) % 100;
            // milliseconds = (int)((time - Mathf.Floor(time)) * 100);

            textTime.text = string.Format("{0:D2} : {1:D2} : {2:D2}", minute, second, milliseconds);

            yield return null;
        }
    }
}
