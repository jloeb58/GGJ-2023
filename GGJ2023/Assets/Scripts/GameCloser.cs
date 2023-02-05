using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCloser : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("GameClose", 22);
    }

    void GameClose()
    {
        Application.Quit();
    }
}
