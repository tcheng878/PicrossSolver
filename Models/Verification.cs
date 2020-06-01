namespace picrosssolver.Models{
    public partial class Board{
        //////////////////////////////////////////////////////////////////////////
        //Checks if a row/column is completely filled out -- ie: no "0"s remaining
        //If so, converts all 1's into 2's 

        //Also checks if all hints have been used. If so, fills all remaining "0"s with "4"s
        public void VerifyRow(int row){ //Checks if the row is completely filled out
            bool flag = true;
            for(int i = 0; i < width; i++){
                if(this.board_state[row, i] == 0){
                    flag = false;
                    break;
                }
            }
            if(flag){
                for(int i = 0; i < width; i++){
                   if(this.board_state[row, i] == 1){
                       this.board_state[row, i] = 2;
                    } 
                }
                board_y_complete[row] = 1;
            }
        }
        public void VerifyColumn(int column){ //Checks if column is completel filled out
            bool flag = true;
            for(int i = 0; i < height; i++){
                if(this.board_state[i, column] == 0){
                    flag = false;
                    break;
                }
            }
            if(flag){
                for(int i = 0; i < height; i++){
                    if(this.board_state[i, column] == 1){
                        this.board_state[i, column] = 2;
                    }
                }
                board_x_complete[column] = 1;
            }
        }

        //These might not trigger if row has been completed by column hints. 
        //Might need another helper function to detect if every hint has been used,
        //but the hints haven't been eliminated from the hints?
        public void CheckHintsRow(int row){ //checks if all hints in a row have been used
            int[] row_hints = this.board_y_hints[row];
            if(row_hints.Length == 0){
                for(int i = 0; i < width; i++){
                    if(this.board_state[row, i] == 0){
                        this.board_state[row, i] = 4;
                    }
                }
                board_y_complete[row] = 1;
            }
        }
        public void CheckHintsColumn(int column){ //checks if all hints in a column have been used
            int[] column_hints = this.board_x_hints[column];
            if(column_hints.Length == 0){
                for(int i = 0; i < height; i++){
                    if(this.board_state[i, column] == 0){
                        this.board_state[i, column] = 4;
                    }
                }
                board_x_complete[column] = 1;
            }
        }
        public void VerifyAllRows(){ //Runs "VerifyRow" for all rows
            for(int i = 0; i < height; i++){
                if(this.board_y_complete[i] != 1){
                    this.VerifyRow(i);
                }
            }
            for(int i = 0; i < height; i++){
                if(this.board_y_complete[i] != 1){
                    this.CheckHintsRow(i);
                }
            }
        }
        public void VerifyAllColumns(){ //Runs "VerifyColumn" for all columns
            for(int i = 0; i < width; i++){
                if(this.board_x_complete[i] != 1){
                    this.VerifyColumn(i);
                }
            }
            for(int i = 0; i < width; i++){
                if(this.board_x_complete[i] != 1){
                    this.CheckHintsColumn(i);
                }
            }
        }
        public void VerifyAll(){ //Runs "VerifyAllRows" and "VerifyAllColumns"
            this.VerifyAllRows();
            this.VerifyAllColumns();
        }
    }
}