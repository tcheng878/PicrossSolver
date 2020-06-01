using System;
using System.Collections.Generic;
using System.Linq;

namespace picrosssolver.Models{
    public partial class Board{
        public void Fillrow(int row){
            for(int i = 0; i < this.width; i++){
                if(this.board_state[row,i] == 0){
                    this.board_state[row,i] = 4;
                }
            }
        }
        public void Fill(){
            for(int i = 0; i < this.height; i++){
                this.Fillrow(i);
            }
        }
    }
}