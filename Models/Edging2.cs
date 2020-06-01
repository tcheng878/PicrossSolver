using System;
using System.Collections.Generic;
using System.Linq;

namespace picrosssolver.Models{
    public partial class Board{
        ////////////////////////////////////////////////////////////////////
        // Looking at filled in squares adjacent to a "4" or edge of board
        public void EdgingRow(int row){
            int[] row_hints = this.board_y_hints[row];
            int counter = 0;
            bool flag = false;
            //start from beginning
            for(int i = 0; i < width; i++){
                if(this.board_state[row, i] == 4){
                    if(flag){
                        break;
                    }
                    counter = 0;
                }
                else if(this.board_state[row, i] == 0){
                    counter++;
                    flag = true;
                }
                else if(this.board_state[row, i] == 1 || this.board_state[row, i] == 2){
                    counter++;
                }
            }
            //count = size of open area
            
            //start from end
        }
        public void EdgingColumn(int row){

        }
        public void EdgeAllRow(){
            for(int i = 0; i < height; i++){
                if(this.board_y_complete[i] != 1){
                    this.EdgingRow(i);
                }
            }
        }
        public void EdgeAllColumn(){
            for(int i = 0; i < width; i++){
                if(this.board_x_complete[i] != 1){
                    this.EdgingColumn(i);
                }
            }
        }
        public void EdgeDetectAll(){
            this.EdgeAllRow();
            this.EdgeAllColumn();
        }
    }
}