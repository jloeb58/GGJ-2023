using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class OtherSceneLoader : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(LoadNext());
    }

    IEnumerator LoadNext()
    {
        AsyncOperation loading = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        yield return null;
    }
}
