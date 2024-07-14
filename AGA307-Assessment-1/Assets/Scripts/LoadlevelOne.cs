using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadlevelOne : MonoBehaviour
{
    public void LoadLevel()
    {
        print("Load The Level");
        SceneManager.LoadScene(1);

    }
}
