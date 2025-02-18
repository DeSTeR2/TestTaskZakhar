using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row : MonoBehaviour
{
    List<RowItem> rows = new List<RowItem>();

    private void Start() {
        for (int i=0; i<transform.childCount; i++) {
            rows.Add(transform.GetChild(i).gameObject.GetComponent<RowItem>());
        }
    }

    public List<RowItem> GetRows() {
        return rows;
    }

    public List<SingleRotationTile> GetRowTiles() {
        List<SingleRotationTile> singleRotationTiles = new List<SingleRotationTile>();
        for (int i=0; i<rows.Count; i++) {
            singleRotationTiles.Add(rows[i].GetRotatedTile());
        }

        return singleRotationTiles;
    }
}
