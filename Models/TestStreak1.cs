using System;
using System.Collections.Generic;
using System.Linq;

namespace picrosssolver.Models{

    public partial class Board{
        ///////////////////////////////////////////////////////////////////
        // Looking if the biggest streak is completed, and is on either end
        public void TestBigRow(int row){ //Looks at biggest values in row, tries to block
            int[] row_hints = this.board_y_hints[row];
            int largest = row_hints.Max();
            int streak_counter = 0;
            int marker = 0;
            int counter = 0;
            bool largest_flag = false;
            
            for(int i = 0; i < width; i++){ //This block is to test if the biggest streak exists in the board_state
                if(this.board_state[row,i] == 1 || this.board_state[row,i] == 2){
                    streak_counter++;
                    if(streak_counter == largest){
                        marker = i + 1; //this marks where the largest is
                        largest_flag = true;
                        break;
                    }
                }
                else{
                    streak_counter = 0;
                }
            }
            foreach(int i in row_hints){ //Make sure the largets hint is unique
                if(i == largest){
                    counter++;
                }
            }
            if(largest_flag){
                if(counter == 1){
                    if(largest == row_hints.First()){
                        for(int i = 0; i < largest; i ++){
                            this.board_state[row, marker - 1 - i] = 2;
                        }
                        try{
                            this.board_state[row, marker] = 4;
                        }
                        catch{}
                        int marker2 = marker - largest - 1;
                        for(int i = marker2; i >= 0; i--){
                            try{
                            if(this.board_state[row, i] != 1){
                                this.board_state[row, i] = 4;
                                }
                            }
                            catch{}
                        }
                        var temp = new List<int>(this.board_y_hints[row]); //seems inefficient
                        temp.RemoveAt(0);
                        this.board_y_hints[row] = temp.ToArray();
                    }
                    if(largest == row_hints.Last()){
                        for(int i = 0; i < largest; i ++){
                            this.board_state[row, marker - 1 - i] = 2;
                        }
                        try{
                            this.board_state[row, marker -1 - largest] = 4;
                        }
                        catch{}
                        for(int i = marker; i < width; i++){
                            try{
                            if(this.board_state[row, i] != 1){
                                this.board_state[row, i] = 4;
                                }
                            }
                            catch{}
                        }
                        var temp = new List<int>(this.board_y_hints[row]); //seems inefficient
                        if(temp.Count > 0)
                            temp.RemoveAt(this.board_y_hints[row].Length - 1);
                        this.board_y_hints[row] = temp.ToArray();
                    }
                }
            }
        }
        public void TestBigColumn(int column){ //Looks at biggest values in col, tries to block
            int[] column_hints = this.board_x_hints[column];
            int largest = column_hints.Max();
            int streak_counter = 0;
            int marker = 0;
            int counter = 0;
            bool largest_flag = false;
            
            for(int i = 0; i < height; i++){ //This block is to test if the biggest streak exists in the board_state
                if(this.board_state[i, column] == 1 || this.board_state[i, column] == 2){
                    streak_counter++;
                    if(streak_counter == largest){
                        marker = i + 1; //this marks where the largest is
                        largest_flag = true;
                        break;
                    }
                }
                else{
                    streak_counter = 0;
                }
            }
            foreach(int i in column_hints){ //Make sure the largets hint is unique
                if(i == largest){
                    counter++;
                }
            }
            if(largest_flag){
                if(counter == 1){
                    if(largest == column_hints.First()){
                        for(int i = 0; i < largest; i ++){
                            this.board_state[marker - 1 - i, column] = 2;
                        }
                        try{
                            this.board_state[marker, column ] = 4;
                        }
                        catch{}
                        int marker2 = marker - largest - 1;
                        for(int i = marker2; i >= 0; i--){
                            try{
                                if(this.board_state[i, column] != 1){
                                    this.board_state[i, column] = 4;
                                }
                            }
                            catch{}
                        }
                        var temp = new List<int>(this.board_x_hints[column]); //seems inefficient
                        temp.RemoveAt(0);
                        this.board_x_hints[column] = temp.ToArray();
                    }
                    if(largest == column_hints.Last()){
                        for(int i = 0; i < largest; i ++){
                            this.board_state[marker - 1 - i, column] = 2;
                        }
                        try{
                            this.board_state[marker -1 - largest, column] = 4;
                        }
                        catch{}
                        for(int i = marker; i < width; i++){
                            try{
                                if(this.board_state[i, column] != 1){
                                    this.board_state[i, column] = 4;
                                }
                            }
                            catch{}
                        }
                        var temp = new List<int>(this.board_x_hints[column]); //seems inefficient
                        if(temp.Count > 0)
                            temp.RemoveAt(this.board_x_hints[column].Length - 1);
                        this.board_x_hints[column] = temp.ToArray();
                    }
                }
            }
        }
        public void TestAllRow(){ //Uses "TestBigRow" on all rows
            for(int i = 0; i < height; i++){
                if(this.board_y_complete[i] != 1){
                    this.TestBigRow(i);
                }
            }
        }
        public void TestAllColumn(){ //Uses "TestBigCOlumn in all columns
            for(int i = 0; i < width; i++){
                if(this.board_x_complete[i] != 1){
                    this.TestBigColumn(i);
                }
            }
        }
        public void TestAll(){ //Uses "TestAllRow" and "TestAllColumn"
            this.TestAllRow();
            this.TestAllColumn();
        }
    
    }
}