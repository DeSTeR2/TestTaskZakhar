using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "Lines", menuName = "Lines/Lines", order = 0)]
public class Lines : ScriptableObject
{
    [SerializeField] public List<LineConnection> lines = new List<LineConnection>();
}
