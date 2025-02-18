using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererCreate : MonoBehaviour
{
    [SerializeField] LineRenderer _connectionLinePrefab;
    [Space]
    [SerializeField] List<Material> _materials = new List<Material>();
    [Space]
    [SerializeField] Lines _lines;

    List<LineRenderer> _linesList = new List<LineRenderer>();

    private void Start() {
        for (int i=0; i< _lines.lines.Count; i++) {
            _linesList.Add(Instantiate(_connectionLinePrefab, transform));
            
            int rngMat = Random.Range(0, _materials.Count);
            _linesList[i].material = _materials[rngMat];
        }
    }

    public List<LineRenderer> GetLines() {
        return _linesList;
    }
}
