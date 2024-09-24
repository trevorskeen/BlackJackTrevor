using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RulesSceneButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void GoToRules()
    {
        SceneManager.LoadScene("RulesScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
