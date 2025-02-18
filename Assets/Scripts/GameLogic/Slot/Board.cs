using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    [SerializeField] Lines _lines;
    [SerializeField] LineRendererCreate _lineCreate;
    [SerializeField] MoneyManager _moneyManager;

    private int times = 0;
    private int _boardSize = 0;

    private bool _autoSpin = false;
    public bool IsSpining = false;

    private List<Row> _rowList= new List<Row>();
    private List<List<RowItem>> _board = new List<List<RowItem>>();
    private ConnectionManager _connectionManager;

    public static Action onBoardRotated;

    private void Start() {
        RowItem.onRowItemRotated += OnRowRotated;

        int width = transform.childCount;
        int height = transform.GetChild(0).childCount;

        _boardSize = width * height;

        for (int i=0; i < width; i++) {
            _rowList.Add(transform.GetChild(i).transform.GetComponent<Row>());
            _board.Add(_rowList[i].GetRows());
        }


        _connectionManager = new ConnectionManager(_lines, _lineCreate.GetLines());
    }

    public void Stop(int p = 0) {
        _autoSpin = false;

    }

    public void AutoSpin() {
        if (!_moneyManager.CanSpin()) return;
        
        _autoSpin = true;
        Spin();
    }

    public void Spin() {

        if (_moneyManager.CanSpin() == false) {
            Stop();
            onBoardRotated?.Invoke();
            return;
        }
        IsSpining = true;
        _moneyManager.Bet();

        _connectionManager.ResetLines();

        for (int i = 0; i < _board.Count; i++) {
            for (int j=0;j < _board[i].Count; j++) {
                _board[i][j].AnimateRotationTiles();
            }
        }
    }

    public void OnRowRotated() {
        times++;
        if (times == _boardSize) {
            StartCoroutine(OnBoardRotated());
            times = 0;
        }
    }

    public IEnumerator OnBoardRotated() {
        List< List<SingleRotationTile> > board = new List<List<SingleRotationTile>> ();
        IsSpining = false;

        for (int i=0; i < _rowList.Count; i++) {
           board.Add(_rowList[i].GetRowTiles());
        }

        _connectionManager.CheckConnection(board);

        yield return new WaitForSeconds(0.7f);

        if (_autoSpin) {
            Spin();
        } else 
        onBoardRotated?.Invoke();
    }

    

    private void OnDestroy() {
        RowItem.onRowItemRotated -= OnRowRotated;
    }
}
