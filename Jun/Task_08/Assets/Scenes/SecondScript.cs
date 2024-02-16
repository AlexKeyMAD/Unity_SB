using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondObject : MonoBehaviour
{
    public Vector3[] RunnersCoordinates;
    public GameObject Human;

    public int speed;

    private GameObject[] Runners;
    private int indexCoordinates = 0;

    private GameObject Runner;


    // Start is called before the first frame update
    void Start()
    {
        Runners = new GameObject[RunnersCoordinates.Length + 1];

        Runners[0] = Instantiate(Human, Vector3.zero, Quaternion.identity);

        for (int i = 1; i <= RunnersCoordinates.Length; i++)
        {
            Runners[i] = Instantiate(Human, RunnersCoordinates[i - 1], Quaternion.identity);
            Runners[i].transform.localScale += Human.transform.localScale * (0.2f * i);
        }

        Runner = Runners[0];

        Debug.Log(Runners.Length);
    }

    // Update is called once per frame
    void Update()
    {
        Runner.transform.position = Vector3.MoveTowards(Runner.transform.position, RunnersCoordinates[indexCoordinates], Time.deltaTime * speed);
        
        Debug.Log(indexCoordinates);

        if (Runner.transform.position == RunnersCoordinates[indexCoordinates])
        {
            Runner = Runners[GetIndexNextRunner(Runner)];

            Runner.transform.LookAt(Runners[GetIndexNextRunner(Runner)].transform);

            indexCoordinates = indexCoordinates == RunnersCoordinates.Length - 1 ? 0 : indexCoordinates + 1;
        }
    }

    private int GetIndexNextRunner(GameObject r)
    {
        int index = 0;

        for (int i = 0; i < Runners.Length; i++)
        {
            if (Runners[i] == r)
            {
                index = i;
            }
        }

        return (index == Runners.Length - 1 ? 0 : index + 1);
    }
}
