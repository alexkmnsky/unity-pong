using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour
{
    public GameObject instruction;

    void OnStart()
    {
        SceneManager.LoadScene("Game");
    }

    // Update is called once per frame
    void Update()
    {
        instruction.SetActive((int)Time.timeSinceLevelLoad % 2 == 0);
    }
}
