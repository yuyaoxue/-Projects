using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMove : MonoBehaviour {

    public void Init()
    {
        index = 1;
        crossPipeCount = 0;
        this.transform.localPosition = new Vector3(2,0,0);
        for (int i = 0; i < pipes.Length; i++)
        {
            pipes[i].transform.localPosition = new Vector3(i * width, Random.Range(Minimum_Y,Maximum_Y), 0);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!GameMananager.Instance.IsStart)
            return;

        if (gameObject.transform.localPosition.x <= (-index * width-1))
        {
             sortPipe();
             index++;
        }
        CalculateScore();
        gameObject.transform.localPosition += Vector3.left * 0.008f;
    }
    private void CalculateScore()
    {
        float this_x = gameObject.transform.localPosition.x;
        if(this_x<=0)
        {
            int temp = Mathf.Abs((int)(this_x / (crossPipeCount*width + 0.5f)));
            if(temp>=1)
            {
                crossPipeCount += temp;
                AudioManager.Instance.PlayAudio(AudioType.Point);
                GameMananager.Instance.SetScore(crossPipeCount);
            }
        }
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
        temp.transform.localPosition = new Vector3(_endTran.localPosition.x + width, Random.Range(Minimum_Y,Maximum_Y), 0);
        pipes[pipes.Length - 1] = temp;
    }


    public void StartGame()
    {
       // Init();
    }

    public void GameOver()
    {

    }

    private Transform _startTran;
    private Transform _endTran;
    private float index = 1;
    private const float width = 1.5f;
    private int crossPipeCount = 0;
    [SerializeField]
    private GameObject[] pipes;

    private const float Maximum_Y = 1f;
    private const float Minimum_Y = -0.5f;

}
