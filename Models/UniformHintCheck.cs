using System.Linq;
using System.Collections.Generic;

namespace picrosssolver.Models{
    public partial class Board{
        ////////////////////////////////////////////////////////////////////////
        //If all hints in a row/column are the same, checks if there is a streak
        //of that size in the board, and checks them off.
        public void UniformHintCheckRow(int row){
            int[] row_hints = this.board_y_hints[row];
            if(row_hints.Length > 0){
                int value = row_hints.Max();
                bool flag = true;
                bool flaglong = false;
                foreach(int i in row_hints){
                    if(i != value){
                        flag = false;
                    }
                }
                int streak_counter = 0;
                int marker = 0;
                if(flag){
                    for(int i = 0; i < width; i++){
                        if(this.board_state[row,i] == 1 || this.board_state[row,i] == 2){
                            if(flaglong){
                                try{
                                    if(this.board_state[row,i] == 1 || this.board_state[row,i] == 2){
                                        flaglong = true;
                                        streak_counter = -1;
                                    }
                                }
                                catch{}
                            }
                            streak_counter++;
                            if(streak_counter == value){
                                try{
                                    if(this.board_state[row,i+1] == 1 || this.board_state[row,i+1] == 2){
                                        flaglong = true;
                                        streak_counter = 0;
                                    }
                                }
                                catch{}
                                if(flaglong == false){
                                    marker = i + 1;
                                    //does order of the hints matter?
                                    try{
                                    this.board_state[row, marker] = 4;
                                    }
                                    catch{}
                                    try{
                                    this.board_state[row, marker - value - 1] = 4;
                                    }
                                    catch{}
                                    for(int j = marker - value ; j < marker; j++){
                                        this.board_state[row, j] = 2;
                                    }
                                    var temp = new List<int>(this.board_y_hints[row]); //seems inefficient
                                    temp.RemoveAt(0);
                                    this.board_y_hints[row] = temp.ToArray();
                                }
                            }
                        }
                        else{
                            flaglong = false;
                            streak_counter = 0;
                        }
                    }
                }
            }
        }
        public void UniformHintCheckColumn(int column){
            int[] column_hints = this.board_x_hints[column];
            if(column_hints.Length > 0){
                int value = column_hints.Max();
                bool flag = true;
                bool flaglong = false;
                foreach(int i in column_hints){
                    if(i != value){
                        flag = false;
                    }
                }
                int streak_counter = 0;
                int marker = 0;
                if(flag){
                    for(int i = 0; i < height; i++){
                        if(this.board_state[i, column] == 1 || this.board_state[i, column] == 2){
                            if(flaglong){
                                try{
                                    if(this.board_state[i, column] == 1 || this.board_state[i, column] == 2){
                                        flaglong = true;
                                        streak_counter = -1;
                                    }
                                }
                                catch{}
                            }
                            streak_counter++;
                            if(streak_counter == value){
                                try{
                                    if(this.board_state[i+1, column] == 1 || this.board_state[i+1, column] == 2){
                                        flaglong = true;
                                        streak_counter = 0;
                                    }
                                }
                                catch{}
                                if(flaglong == false){
                                    marker = i + 1;
                                    //does order of the hints matter?
                                    try{
                                    this.board_state[marker, column] = 4;
                                    }
                                    catch{}
                                    try{
                                    this.board_state[marker - value - 1, column] = 4;
                                    }
                                    catch{}
                                    for(int j = marker - value ; j < marker; j++){
                                        this.board_state[ j, column] = 2;
                                    }
                                    var temp = new List<int>(this.board_x_hints[column]); //seems inefficient
                                    temp.RemoveAt(0);
                                    this.board_x_hints[column] = temp.ToArray();
                                }
                            }
                        }
                        else{
                            flaglong = false;
                            streak_counter = 0;
                        }
                    }
                }
            }
        }
        public void UniformHintCheckAllRows(){
            for(int i = 0; i < height; i++){
                if(this.board_y_complete[i] != 1){
                    this.UniformHintCheckRow(i);
                }
            }
        }
        public void UniformHintCheckAllColumns(){
            for(int i = 0; i < width; i++){
                if(this.board_x_complete[i] != 1){
                    this.UniformHintCheckColumn(i);
                }
            }
        }   
        public void UniformHintCheck(){
            this.UniformHintCheckAllRows();
            this.UniformHintCheckAllColumns();
        }
    }
}