using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningPipe : MonoBehaviour
{

    PipeConnection Pipe;
    private void Start()
    {
        Pipe = GetComponent<PipeConnection>();
    }

    private void Update()
    {

        if (Pipe.hasWater)
        {
            Invoke("Complited", 0.5f);
        }
    }
    void Complited()
    {
        GameManager.instance.Complited();
    }
}
