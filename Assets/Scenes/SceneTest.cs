using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTest : MonoBehaviour
{
    public void SceneTestClickListener(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}