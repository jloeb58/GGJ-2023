using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    private Color C;
    void Start()
    {
        C = GetComponent<Image>().color;
        StartCoroutine(Fading());
    }

    IEnumerator Fading() {
        for (float alpha = 1f; alpha >= 0.0f; alpha -= 0.1f)
        {
            C.a = alpha;
            GetComponent<Image>().color = C;
            Debug.Log(alpha);
            yield return new WaitForSeconds(.3f);
            if (alpha <=.1f) 
            {
                Destroy(gameObject);
            }
        }
    }
}
