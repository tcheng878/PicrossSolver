using System;
using System.Collections.Generic;
using System.Linq;

namespace picrosssolver.Models{
//USING http://liouh.com/picross/ seed 1587885116876 

// 10 x 10 1588023891904

///////////////////////////////////////////////////////
//This is the MAIN file!
//Contains helper functions, runs the code.
//Files are named in order of creation: "name"+"number".cs
//First is SolveInit0
//Second is TestStreak1...
//Code might not be that efficient, but is not brute forced!

    public  partial class Board{
        public List<int[]> board_x_hints;
        public List<int[]> board_y_hints;

        public int[,] board_state; 
        //0 = not solve, 1 = is true, not finished, 2 is finished, 4 = not true

        public int[] board_x_complete;
        public int[] board_y_complete;

        public int width;
        public int height;

        public Board(List<int[]> board_width, List<int[]> board_height){  //Creates Board fields
            board_x_hints = board_width;
            board_y_hints = board_height;
            width = board_width.Count;
            height = board_height.Count;
            board_state = new int[height,width];
            board_x_complete = new int[width];
            board_y_complete = new int[height];

        }
        //////////////////////////////////////////////////////////////////////
        ////////////// List of what each thing under Solver does /////////////
        //////////////////////////////////////////////////////////////////////

        // Verification.cs: If a row/col has no "0"s remaining, marks as completed
        // If a row/col has no hints remaining, marks all "0"s as "4"s, marks as completed

        // UniformHintCheck.cs: If all remaining hints in a row/col are the same number, 
        // looks for streaks the size of that hint. If any are found, "4"s are placed
        // at beginning and end of the streak, and the FIRST ITEM in the hints is removed.
        // Since all hints are the same, this shouldn't make mistakes, but will cause
        // the hints to lose order of which one came first, etc. Might need fixing

        // SolveInit0.cs: Currently should only run once when Solver is run for the
        // first time. Calculates the overlaps in each row/col, and places a "1" where
        // any overlap occurs. DOES NOT HAVE DETECTING FOR WHETHER A "2" CURRENTLY EXISTS,
        // HENCE IT SHOULD ONLY BE RUN ONCE AT THE MOMENT.

        // TestStreak1.cs: Kind of misleading name at the moment. If the largest hint is a
        // unique value, searches for any streak the size of the largest hint exists on
        // the board state. If so, marks that streak as "2"s, places "4"s at the ends,
        // and removes the hint. Only works if the largest as first or last item in hints.

        // Edging2.cs: Checks if there is a square adjacent/near the left/rightmost edge
        // of the board or against a "4". If so, tries to fill in adjacent squares based
        // on the length of the relevant hint. 
        // ex: |4 0 1 0 0 0... hint = 4           | 1 0 0 0 0 1 | hint = 1, 1
        // =>  |4 0 1 1 1 0...                  =>| 1 4 0 0 4 1 |
        public void Solver(){
            if(this.isSolved() == false){ //should use while loop later!!!!
                this.GoThroughStart(); //Runs SolveInit0.cs   Should only run once?
                this.TestAll(); //Runs this.TestStreak1.cs
                this.EdgeDetectAll(); //Runs Edging2.cs

                //make sure this doesn't overwrite 1s or 2s!
                this.UniformHintCheck(); //Runs UniformHintCheck.cs
                this.VerifyAll(); //Runs Verification.cs
                // this.Fill();
            }
        }
        public bool isSolved(){ //See if the entire board has been completely solved
            foreach(int i in board_x_complete){
                if(i == 0){
                    return false;
                }
            }
            foreach(int i in board_y_complete){
                if(i == 0){
                    return false;
                }
            }
            return true;
        }
        
        //depreciated by displaying on website, mostly for debugging
        public void PrintBoard(){ //Prints out the board_state
            int counter = 0;
            string stringout = "";
            foreach(int i in this.board_state){
                if(counter%width == 0){
                    Console.WriteLine(stringout);
                    stringout = "";
                }
                stringout += i + " ";
                counter++;
            }
            Console.WriteLine(stringout);
        }
    }
}