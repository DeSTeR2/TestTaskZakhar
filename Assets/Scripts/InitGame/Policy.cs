using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Policy : MonoBehaviour
{
    [SerializeField] string _link;

    public void OpenLink() {
        Application.OpenURL(_link);
    }
}
