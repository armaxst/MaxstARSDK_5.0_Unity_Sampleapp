using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitSplashScreen());
    }

    private IEnumerator WaitSplashScreen()
    {
        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene("Home");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
