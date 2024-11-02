using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(CountdownAndSwitchScene());
    }

    private IEnumerator CountdownAndSwitchScene()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("MainMenu");
    }
    void Update()
    {
        
    }
}
