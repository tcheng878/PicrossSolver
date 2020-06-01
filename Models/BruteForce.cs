using System;

namespace picrosssolver.Models{
    public partial class Board{
        public void BruteForce(){
            this.GoThroughStart(); //Runs SolveInit0.cs   Should only run once?
            this.TestAll(); //Runs this.TestStreak1.cs
            this.EdgeDetectAll(); //Runs Edging2.cs

            //make sure this doesn't overwrite 1s or 2s!
            this.UniformHintCheck(); //Runs UniformHintCheck.cs
            this.VerifyAll(); //Runs Verification.cs

            //start brute forcing
            this.BruteRow(1);
        }
        public void BruteRow(int row){
            int pointer = 0;
            foreach(int i in board_y_hints[row]){
                int j = 0;
                while(j < i){
                    if(this.board_state[row, pointer] == 0){
                        this.board_state[row, pointer] = 1;
                        j++;
                        pointer++;
                    }
                    else if(this.board_state[row, pointer] == 1){
                        j++;
                        pointer++;
                    }
                    else if(this.board_state[row, pointer] == 4){
                        //if this hits, then the hint doesn't fit in the current slot.
                        Console.WriteLine("broke lmao-- current slot too small");
                        break;
                    }
                    this.PrintBoard();
                }
                if(pointer < width){
                    if(this.board_state[row, pointer] == 0){
                        this.board_state[row, pointer] = 4;
                        pointer++;   
                    }
                    else{
                        Console.WriteLine("broke lmao-- too early");
                        //if this hits, then throw an error.
                    } 
                }
            }
            while(pointer < width){
                if(this.board_state[row, pointer] == 1){
                    //if this hits, then throw an error.
                    Console.WriteLine("broke lmao-- found 1's after hints");
                }
                pointer++;
            }
        }
    }
}