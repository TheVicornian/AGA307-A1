using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadlevelOne : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void LoadLevel()
    {
        print("Load The Level");
        SceneManager.LoadScene(1);

    }
}
