using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMove : MonoBehaviour {

    void Start()
    {

        init();
    }

    private void init()
    {
        this.transform.localPosition = new Vector3(2,0,0);
        for (int i = 0; i < pipes.Length; i++)
        {
            pipes[i].transform.localPosition = new Vector3(i * width, 0, 0);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!GameMananager.Instance.isStart)
            return;

        if (gameObject.transform.localPosition.x <= (-index * width-1))
        {
             sortPipe();
             index++;
        }
        gameObject.transform.localPosition += Vector3.left * 0.008f;
    }
    private void sortPipe()
    {
        GameObject temp = null;
        temp = pipes[0];
        _endTran = pipes[pipes.Length - 1].transform;
        for (int i = 0; i < pipes.Length; i++)
        {
            if(i< pipes.Length-1)
              pipes[i] = pipes[i+1];
        }
        temp.transform.localPosition = new Vector3(_endTran.localPosition.x + width, 0, 0);
        pipes[pipes.Length - 1] = temp;
    }

    private Transform _startTran;
    private Transform _endTran;
    private float index = 1;
    private float width = 1;
    [SerializeField]
    private GameObject[] pipes;
}
