using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sceneback : MonoBehaviour
{
    // Start is called before the first frame update
    public void SceneTransitionBack()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
