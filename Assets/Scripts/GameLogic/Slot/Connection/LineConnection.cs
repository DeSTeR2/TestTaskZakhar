using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LineConnection", menuName = "Lines/LineConnection", order = 1)]
public class LineConnection : ScriptableObject
{
    [SerializeField] public int[] line = new int[5];
}
