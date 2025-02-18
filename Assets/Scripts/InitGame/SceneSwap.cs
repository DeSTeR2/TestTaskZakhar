using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwap : MonoBehaviour
{
    [SerializeField] string _sceneName;

    public void LoadScene() {
        SceneManager.LoadScene(_sceneName);
    }
}
