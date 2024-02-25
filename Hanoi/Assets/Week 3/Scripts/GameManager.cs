using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Battleship
{



    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private int[,] grid = new int[,]
        {
            //Top left is (0,0)
            {1,1,0,0,1 },
            {0,0,0,0,0 },
            {0,0,1,0,1 },
            {1,0,1,0,0 },
            {1,0,1,0,1 },
            //Bottom right is (4,4)
        };
        //represents where the player has fired
        private bool[,] hits;

        //Total rows and columns we have
        private int nRows;
        private int nCols;
        //Current rows and columns we are on
        private int row;
        private int col;
        //correctly hit ships
        private int score;
        //total game time
        private int time;

        //Parent of all cells
        [SerializeField] Transform gridRoot;
        //Template used to populate the grid
        [SerializeField] GameObject CellPrefab;
        [SerializeField] GameObject winLabel;
        [SerializeField] TextMeshProUGUI timeLabel;
        [SerializeField] TextMeshProUGUI scoreLabel;


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        Transform GetCurrentCell()
        {
            int index = (row * nCols) + col;

            return gridRoot.GetChild(index);
        }


        void SelectCurrentCell()
        {

            Transform cell = GetCurrentCell();

            Transform cursor = cell.Find("Cursor");
            cursor.gameObject.SetActive(true);
        }

        void UnselectCurrentCell()
        {

            Transform cell = GetCurrentCell();

            Transform cursor = cell.Find("Cursor");
            cursor.gameObject.SetActive(false);
        }

       public void MoveHorizontal(int amt)
        {

            UnselectCurrentCell();

            col += amt;

            col = Mathf.Clamp(col, 0, nCols - 1);

            SelectCurrentCell();
        }

       public void MoveVertical(int amt)
        {

            UnselectCurrentCell();

            row += amt;

            row = Mathf.Clamp(row, 0, nRows - 1);

            SelectCurrentCell();
        }

        private void Awake()
        {
            nRows = grid.GetLength(0);
            nCols = grid.GetLength(1);
            //create identical array
            hits = new bool[nRows, nCols];

            for(int i = 0; i < nRows * nCols; i++)
            {
                Instantiate(CellPrefab, gridRoot);
            }

            //
           

           
        }



    
    }
}