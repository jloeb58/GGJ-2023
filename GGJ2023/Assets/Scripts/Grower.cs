using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grower : MonoBehaviour
{
    float what;
    public GameObject dirt;
    // Start is called before the first frame update
    void OnEnable()
    {
        what = dirt.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (what <= 367f) {
            what = what * 31.3f;
            dirt.transform.localScale = new Vector3(what, what, what);
        }
    }
}
