using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using picrosssolver.Models;

namespace picrosssolver.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<int[]> board_x = new  List<int[]>{ //THESE ARE COLUMNS
                new int[] {1,1},
                new int[] {4},
                new int[] {5},
                new int[] {1,1},
                new int[] {1,1},
                new int[] {2},
                new int[] {4},
                new int[] {1,1},
                new int[] {5},
                new int[] {3},
            };
            List<int[]> board_y = new  List<int[]>{ //THESE ARE ROWS
                new int[] {3,3}, 
                new int[] {2,1,1,1},
                new int[] {3,2,2},
                new int[] {3,6},
                new int[] {2,2},
            };
            // List<int[]> board_x = new  List<int[]>{ //THESE ARE COLUMNS
            //         new int[] {1,2,1,2},
            //         new int[] {2,1},
            //         new int[] {1,2,2},
            //         new int[] {3,5},
            //         new int[] {6,1},
            //         new int[] {1,2},
            //         new int[] {1,2,3},
            //         new int[] {2,1,1},
            //         new int[] {1,2},
            //         new int[] {1,3},
            // };
            // List<int[]> board_y = new  List<int[]>{ //THESE ARE ROWS
            //         new int[] {2,1},
            //         new int[] {1,1,2,2},
            //         new int[] {1,3,1},
            //         new int[] {1,2,1},
            //         new int[] {1,3},
            //         new int[] {1,3,2},
            //         new int[] {2,2},
            //         new int[] {1,3,4},
            //         new int[] {4,1,1},
            //         new int[] {2,1},
            // };

            Board temp = new Board(board_x, board_y);
            // temp.board_state[0, 4] = 1;
            ViewBag.output = temp.board_state;
            ViewBag.width = temp.width;
            ViewBag.height = temp.height;

            ///////////////////////////////
            // User Processing Start Here//
            ///////////////////////////////

            temp.Solver();
            // temp.BruteForce();
            temp.PrintBoard();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
