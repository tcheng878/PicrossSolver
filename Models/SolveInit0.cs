using System;
using System.Collections.Generic;
using System.Linq;

namespace picrosssolver.Models{
    public partial class Board{
        ///////////////////////////////////////////////////////////////////////////////
        //Looking for where start/end positions overlap      
        //For SolveRow/SolveColumn, -10 represents the "blank" values between hints
        //First hint squares are 10, 2nd hint are 11, 3rd 12, etc
        //ie: 1,3 would be 10, -10, 11, 11, 11
                public void SolveRow(int row){ //temp solve row
            int[] check_row = new int[width];
            int[] check_row_r = new int[width];
            int[] row_hints = this.board_y_hints[row];
            int column = 0;
            for(int i = 0; i < row_hints.Length; i++){ //generate check_row
                for(int j = 0; j < row_hints[i]; j++){
                    check_row[column] = i + 10;
                    column++; 
                }
                try{
                    check_row[column] = -10;
                }
                catch{}
                column++;
            }
            column = width - 1;
            for(int i = row_hints.Length - 1; i >= 0; i--){ //generate check_row_r (r = reverse)
                for(int j = 0; j < row_hints[i]; j++){
                    check_row_r[column] = i + 10;
                    column--;
                }
                try{
                    check_row_r[column] = -10;
                }
                catch{}
                column--;
            }
            for(int i = 0; i < width; i++){ //if two numbers match, then it's a "1"
                if(check_row[i] > 0 && check_row_r[i] > 0){
                    if(check_row[i] == check_row_r[i]){
                    this.board_state[row, i] = 1;
                    }
                }
            }
        }
        public void SolveColumn(int column){ //temp solve column
            int[] check_col = new int[height];
            int[] check_col_r = new int[height];
            int[] col_hints = this.board_x_hints[column];
            int row = 0;
            for(int i = 0; i < col_hints.Length; i++){ //generate check_col
                for(int j = 0; j < col_hints[i]; j++){
                    check_col[row] = i + 10;
                    row++;
                }
                try{
                    check_col[row] = -10;
                }
                catch{}
                row++;
            }
            row = height - 1;
            for(int i = col_hints.Length - 1; i >= 0; i--){ //generate check_col_r (r = reverse)
                for(int j = 0; j < col_hints[i]; j++){
                    check_col_r[row] = i + 10;
                    row--;
                }
                try{
                    check_col_r[row] = -10;
                }
                catch{}
                row--;
            }
            for(int i = 0; i < height; i++){ //if two numbers match, then it's a "1"
                if(check_col[i] > 0 && check_col_r[i] > 0){
                    if(check_col[i] == check_col_r[i]){
                        this.board_state[i, column] = 1;
                    }
                }
            }
        }
        public void GoThroughRow(){ //Uses "SolveRow" on every row
            for(int i = 0; i < height; i++){
                this.SolveRow(i);
            }
        }
        public void GoThroughColumn(){ //Uses "SolveColumn" on every row
            for(int i = 0; i < width; i++){
                this.SolveColumn(i);
            }
        }
        public void GoThroughStart(){ //Uses "GoThroughRow" and "GoThroughColumn"
            this.GoThroughRow();
            this.GoThroughColumn();
        }

    }
}