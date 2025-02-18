using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ConnectionManager
{
    [SerializeField] Lines _lines;
    [SerializeField] List<LineRenderer> _linesRenderers;

    public static Action<int, SingleRotationTile> onLineWin;
    public static Action onConnectionChecked;

    public ConnectionManager(Lines lines, List<LineRenderer> lineRenderers) {
        _lines = lines;
        _linesRenderers = lineRenderers;
    }

    public void ResetLines() {
        for (int i = 0; i < _linesRenderers.Count; i++) {
            _linesRenderers[i].positionCount = 0;
        }
    }

    public void CheckConnection(List<List<SingleRotationTile>> board) {

        for (int i=0; i<_lines.lines.Count; i++) {
            int[] line = _lines.lines[i].line;
            _linesRenderers[i].positionCount = line.Length;

            int connectionNumber = 0;
            int startX = 0;
            int startY = line[0];

            string fullLine = "";

            for (int j=0; j<line.Length; j++) {
                int x = j;
                int y = line[j];

                Vector3 linePosition = board[x][y].gameObject.transform.position;
                linePosition.z -= 0.5f;

                if (_linesRenderers.Count > i)
                    _linesRenderers[i].SetPosition(j, linePosition);

                fullLine += y.ToString() + " ";

                if (SingleRotationTile.CompareTiles(board[startX][startY], board[x][y])) {
                    connectionNumber++;
                }
            }

            if (connectionNumber <= 1) {
                _linesRenderers[i].positionCount = 0;
            } else {
                onLineWin?.Invoke(connectionNumber, board[startX][startY]);
            }

            Debug.Log($"Line #{i + 1}. Connections {connectionNumber}. FullLine {fullLine}");
        }

        onConnectionChecked?.Invoke();
    }
}
