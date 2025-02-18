using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    private async void Start()
    {
        await Task.Delay(3000);
        SceneManager.LoadScene(1);
    }
}
