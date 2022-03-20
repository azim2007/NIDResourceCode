using System;
using RubiksCube;

namespace RubicsCubeSimulator
{
    class Program
    {
        static void InputCube(Color[][] colors, ref Cube cube)
        {
            InputSide(colors[0], ref cube.yellowSide);
            InputSide(colors[1], ref cube.greenSide);
            InputSide(colors[2], ref cube.whiteSide);
            InputSide(colors[3], ref cube.blueSide);
            InputSide(colors[4], ref cube.orangeSide);
            InputSide(colors[5], ref cube.redSide);
        }

        static void InputSide(Color[] colors, ref Side sideOfCube)
        {
            sideOfCube.upLeftAngle = colors[0];
            sideOfCube.upEdge = colors[1];
            sideOfCube.upRightAngle = colors[2];
            sideOfCube.rightEdge = colors[3];
            sideOfCube.downRightAngle = colors[4];
            sideOfCube.downEdge = colors[5];
            sideOfCube.downLeftAngle = colors[6];
            sideOfCube.leftEdge = colors[7];

        }

        static void Drive(string scramble, ref Cube cube, bool bySteps)
        {
            var turns = scramble.Split(" ");
            foreach (var e in turns)
            {
                if (bySteps)
                {
                    Console.ReadLine();
                }
                if (e == "R")
                {
                    cube.R();
                }
                else if (e == "R'")
                {
                    cube.RContr();
                }
                else if (e == "R2")
                {
                    cube.RDouble();
                }
                else if (e == "D")
                {
                    cube.D();
                }
                else if (e == "D'")
                {
                    cube.DContr();
                }
                else if (e == "D2")
                {
                    cube.DDouble();
                }
                else if (e == "L")
                {
                    cube.L();
                }
                else if (e == "L'")
                {
                    cube.LContr();
                }
                else if (e == "L2")
                {
                    cube.LDouble();
                }
                else if (e == "U")
                {
                    cube.U();
                }
                else if (e == "U'")
                {
                    cube.UContr();
                }
                else if (e == "U2")
                {
                    cube.UDouble();
                }
                else if (e == "F")
                {
                    cube.F();
                }
                else if (e == "F'")
                {
                    cube.FContr();
                }
                else if (e == "F2")
                {
                    cube.FDouble();
                }
                else if (e == "B")
                {
                    cube.B();
                }
                else if (e == "B'")
                {
                    cube.BContr();
                }
                else if (e == "B2")
                {
                    cube.BDouble();
                }
                else
                {
                    Console.WriteLine("не удалось считать скрамбл(");
                    break;
                }

                if (bySteps)
                {
                    PrintCube(ref cube);
                }
            }
        }

        static void ResetCube(ref Cube cube)
        {
            Color[][] colors = new Color[6][];
            int sideColor;
            for (int j = 0; j < 6; j++)
            {
                if (j == 0)
                    sideColor = 1;
                else if (j == 1)
                    sideColor = 2;
                else if (j == 2)
                    sideColor = 0;
                else if (j == 3)
                    sideColor = 3;
                else if (j == 4)
                    sideColor = 4;
                else
                    sideColor = 5;
                colors[j] = new Color[8];
                for (int i = 0; i < 8; i++)
                {
                    colors[j][i] = (Color)sideColor;
                }
            }
            InputCube(colors, ref cube);
        }

        static string ConvertColorToString(Color color)
        {
            if (color == Color.blue)
                return "Blue";
            else if (color == Color.green)
                return "Green";
            else if (color == Color.orange)
                return "Orange";
            else if (color == Color.red)
                return "Red";
            else if (color == Color.white)
                return "White";
            else 
                return "Yellow";
        }

        static string ConvertColorToPythonString(Color color)
        {
            if (color == Color.blue)
                return "B";
            else if (color == Color.green)
                return "F";
            else if (color == Color.orange)
                return "R";
            else if (color == Color.red)
                return "L";
            else if (color == Color.white)
                return "D";
            else
                return "U";
        }

        static string ConvertColorToPythonString2(Color color)
        {
            if(color == Color.white)
            {
                return "w";
            }
            else if(color == Color.yellow)
            {
                return "y";
            }
            else if (color == Color.green)
            {
                return "r";
            }
            else if (color == Color.orange)
            {
                return "g";
            }
            else if (color == Color.blue)
            {
                return "o";
            }
            return "b";
        }

        static string ToPythonString(ref Cube cube)
        {
            string pyStr = ConvertColorToPythonString(cube.yellowSide.upLeftAngle) + ConvertColorToPythonString(cube.yellowSide.upEdge) + ConvertColorToPythonString(cube.yellowSide.upRightAngle);
            pyStr = pyStr + ConvertColorToPythonString(cube.yellowSide.leftEdge) + "U" + ConvertColorToPythonString(cube.yellowSide.rightEdge);
            pyStr = pyStr + ConvertColorToPythonString(cube.yellowSide.downLeftAngle) + ConvertColorToPythonString(cube.yellowSide.downEdge) + ConvertColorToPythonString(cube.yellowSide.downRightAngle);

            pyStr = pyStr + ConvertColorToPythonString(cube.orangeSide.upLeftAngle) + ConvertColorToPythonString(cube.orangeSide.upEdge) + ConvertColorToPythonString(cube.orangeSide.upRightAngle);
            pyStr = pyStr + ConvertColorToPythonString(cube.orangeSide.leftEdge) + "R" + ConvertColorToPythonString(cube.orangeSide.rightEdge);
            pyStr = pyStr + ConvertColorToPythonString(cube.orangeSide.downLeftAngle) + ConvertColorToPythonString(cube.orangeSide.downEdge) + ConvertColorToPythonString(cube.orangeSide.downRightAngle);

            pyStr = pyStr + ConvertColorToPythonString(cube.greenSide.upLeftAngle) + ConvertColorToPythonString(cube.greenSide.upEdge) + ConvertColorToPythonString(cube.greenSide.upRightAngle);
            pyStr = pyStr + ConvertColorToPythonString(cube.greenSide.leftEdge) + "F" + ConvertColorToPythonString(cube.greenSide.rightEdge);
            pyStr = pyStr + ConvertColorToPythonString(cube.greenSide.downLeftAngle) + ConvertColorToPythonString(cube.greenSide.downEdge) + ConvertColorToPythonString(cube.greenSide.downRightAngle);

            pyStr = pyStr + ConvertColorToPythonString(cube.whiteSide.upLeftAngle) + ConvertColorToPythonString(cube.whiteSide.upEdge) + ConvertColorToPythonString(cube.whiteSide.upRightAngle);
            pyStr = pyStr + ConvertColorToPythonString(cube.whiteSide.leftEdge) + "D" + ConvertColorToPythonString(cube.whiteSide.rightEdge);
            pyStr = pyStr + ConvertColorToPythonString(cube.whiteSide.downLeftAngle) + ConvertColorToPythonString(cube.whiteSide.downEdge) + ConvertColorToPythonString(cube.whiteSide.downRightAngle);

            pyStr = pyStr + ConvertColorToPythonString(cube.redSide.upLeftAngle) + ConvertColorToPythonString(cube.redSide.upEdge) + ConvertColorToPythonString(cube.redSide.upRightAngle);
            pyStr = pyStr + ConvertColorToPythonString(cube.redSide.leftEdge) + "L" + ConvertColorToPythonString(cube.redSide.rightEdge);
            pyStr = pyStr + ConvertColorToPythonString(cube.redSide.downLeftAngle) + ConvertColorToPythonString(cube.redSide.downEdge) + ConvertColorToPythonString(cube.redSide.downRightAngle);

            pyStr = pyStr + ConvertColorToPythonString(cube.blueSide.downRightAngle) + ConvertColorToPythonString(cube.blueSide.downEdge) + ConvertColorToPythonString(cube.blueSide.downLeftAngle);
            pyStr = pyStr + ConvertColorToPythonString(cube.blueSide.rightEdge) + "B" + ConvertColorToPythonString(cube.blueSide.leftEdge);
            pyStr = pyStr + ConvertColorToPythonString(cube.blueSide.upRightAngle) + ConvertColorToPythonString(cube.blueSide.upEdge) + ConvertColorToPythonString(cube.blueSide.upLeftAngle);
            return pyStr;

        }

        static string CubeToPythonString2(ref Cube cube)
        {
            string pyStr = ConvertColorToPythonString2(cube.yellowSide.upLeftAngle) + ConvertColorToPythonString2(cube.yellowSide.upEdge) + ConvertColorToPythonString2(cube.yellowSide.upRightAngle);
            pyStr = pyStr + ConvertColorToPythonString2(cube.yellowSide.leftEdge) + "y" + ConvertColorToPythonString2(cube.yellowSide.rightEdge);
            pyStr = pyStr + ConvertColorToPythonString2(cube.yellowSide.downLeftAngle) + ConvertColorToPythonString2(cube.yellowSide.downEdge) + ConvertColorToPythonString2(cube.yellowSide.downRightAngle);

            pyStr = pyStr + ConvertColorToPythonString2(cube.redSide.upLeftAngle) + ConvertColorToPythonString2(cube.redSide.upEdge) + ConvertColorToPythonString2(cube.redSide.upRightAngle);
            pyStr = pyStr + ConvertColorToPythonString2(cube.redSide.leftEdge) + "b" + ConvertColorToPythonString2(cube.redSide.rightEdge);
            pyStr = pyStr + ConvertColorToPythonString2(cube.redSide.downLeftAngle) + ConvertColorToPythonString2(cube.redSide.downEdge) + ConvertColorToPythonString2(cube.redSide.downRightAngle);

            pyStr = pyStr + ConvertColorToPythonString2(cube.greenSide.upLeftAngle) + ConvertColorToPythonString2(cube.greenSide.upEdge) + ConvertColorToPythonString2(cube.greenSide.upRightAngle);
            pyStr = pyStr + ConvertColorToPythonString2(cube.greenSide.leftEdge) + "r" + ConvertColorToPythonString2(cube.greenSide.rightEdge);
            pyStr = pyStr + ConvertColorToPythonString2(cube.greenSide.downLeftAngle) + ConvertColorToPythonString2(cube.greenSide.downEdge) + ConvertColorToPythonString2(cube.greenSide.downRightAngle);

            pyStr = pyStr + ConvertColorToPythonString2(cube.orangeSide.upLeftAngle) + ConvertColorToPythonString2(cube.orangeSide.upEdge) + ConvertColorToPythonString2(cube.orangeSide.upRightAngle);
            pyStr = pyStr + ConvertColorToPythonString2(cube.orangeSide.leftEdge) + "g" + ConvertColorToPythonString2(cube.orangeSide.rightEdge);
            pyStr = pyStr + ConvertColorToPythonString2(cube.orangeSide.downLeftAngle) + ConvertColorToPythonString2(cube.orangeSide.downEdge) + ConvertColorToPythonString2(cube.orangeSide.downRightAngle);

            pyStr = pyStr + ConvertColorToPythonString2(cube.blueSide.downRightAngle) + ConvertColorToPythonString2(cube.blueSide.downEdge) + ConvertColorToPythonString2(cube.blueSide.downLeftAngle);
            pyStr = pyStr + ConvertColorToPythonString2(cube.blueSide.rightEdge) + "o" + ConvertColorToPythonString2(cube.blueSide.leftEdge);
            pyStr = pyStr + ConvertColorToPythonString2(cube.blueSide.upRightAngle) + ConvertColorToPythonString2(cube.blueSide.upEdge) + ConvertColorToPythonString2(cube.blueSide.upLeftAngle);

            pyStr = pyStr + ConvertColorToPythonString2(cube.whiteSide.upLeftAngle) + ConvertColorToPythonString2(cube.whiteSide.upEdge) + ConvertColorToPythonString2(cube.whiteSide.upRightAngle);
            pyStr = pyStr + ConvertColorToPythonString2(cube.whiteSide.leftEdge) + "w" + ConvertColorToPythonString2(cube.whiteSide.rightEdge);
            pyStr = pyStr + ConvertColorToPythonString2(cube.whiteSide.downLeftAngle) + ConvertColorToPythonString2(cube.whiteSide.downEdge) + ConvertColorToPythonString2(cube.whiteSide.downRightAngle);

            return pyStr;
        }

        static void PrintCube(ref Cube cube)
        {
            Console.Clear();
            Console.WriteLine("    " + ConvertColorToString(cube.yellowSide.upLeftAngle)[0] + ConvertColorToString(cube.yellowSide.upEdge)[0] + ConvertColorToString(cube.yellowSide.upRightAngle)[0]);
            Console.WriteLine("    " + ConvertColorToString(cube.yellowSide.leftEdge)[0] + "Y" + ConvertColorToString(cube.yellowSide.rightEdge)[0]);
            Console.WriteLine("    " + ConvertColorToString(cube.yellowSide.downLeftAngle)[0] + ConvertColorToString(cube.yellowSide.downEdge)[0] + ConvertColorToString(cube.yellowSide.downRightAngle)[0]);
            Console.WriteLine();
            Console.WriteLine("" + ConvertColorToString(cube.redSide.upLeftAngle)[0] + ConvertColorToString(cube.redSide.upEdge)[0] + ConvertColorToString(cube.redSide.upRightAngle)[0] + " " + ConvertColorToString(cube.greenSide.upLeftAngle)[0] + ConvertColorToString(cube.greenSide.upEdge)[0] + ConvertColorToString(cube.greenSide.upRightAngle)[0] + " " + ConvertColorToString(cube.orangeSide.upLeftAngle)[0] + ConvertColorToString(cube.orangeSide.upEdge)[0] + ConvertColorToString(cube.orangeSide.upRightAngle)[0] + " ");
            Console.WriteLine(ConvertColorToString(cube.redSide.leftEdge)[0] + "R" + ConvertColorToString(cube.redSide.rightEdge)[0] + " " + ConvertColorToString(cube.greenSide.leftEdge)[0] + "G" + ConvertColorToString(cube.greenSide.rightEdge)[0] + " " + ConvertColorToString(cube.orangeSide.leftEdge)[0] + "O" + ConvertColorToString(cube.orangeSide.rightEdge)[0] + " ");
            Console.WriteLine("" + ConvertColorToString(cube.redSide.downLeftAngle)[0] + ConvertColorToString(cube.redSide.downEdge)[0] + ConvertColorToString(cube.redSide.downRightAngle)[0] + " " + ConvertColorToString(cube.greenSide.downLeftAngle)[0] + ConvertColorToString(cube.greenSide.downEdge)[0] + ConvertColorToString(cube.greenSide.downRightAngle)[0] + " " + ConvertColorToString(cube.orangeSide.downLeftAngle)[0] + ConvertColorToString(cube.orangeSide.downEdge)[0] + ConvertColorToString(cube.orangeSide.downRightAngle)[0] + " ");
            Console.WriteLine();
            Console.WriteLine("    " + ConvertColorToString(cube.whiteSide.upLeftAngle)[0] + ConvertColorToString(cube.whiteSide.upEdge)[0] + ConvertColorToString(cube.whiteSide.upRightAngle)[0]);
            Console.WriteLine("    " + ConvertColorToString(cube.whiteSide.leftEdge)[0] + "W" + ConvertColorToString(cube.whiteSide.rightEdge)[0]);
            Console.WriteLine("    " + ConvertColorToString(cube.whiteSide.downLeftAngle)[0] + ConvertColorToString(cube.whiteSide.downEdge)[0] + ConvertColorToString(cube.whiteSide.downRightAngle)[0]);
            Console.WriteLine();
            Console.WriteLine("    " + ConvertColorToString(cube.blueSide.upLeftAngle)[0] + ConvertColorToString(cube.blueSide.upEdge)[0] + ConvertColorToString(cube.blueSide.upRightAngle)[0]);
            Console.WriteLine("    " + ConvertColorToString(cube.blueSide.leftEdge)[0] + "B" + ConvertColorToString(cube.blueSide.rightEdge)[0]);
            Console.WriteLine("    " + ConvertColorToString(cube.blueSide.downLeftAngle)[0] + ConvertColorToString(cube.blueSide.downEdge)[0] + ConvertColorToString(cube.blueSide.downRightAngle)[0]);
        }

        static string IntToMove(int number)
        {
            if (number == 0)
                return "R";
            else if (number == 1)
                return "R'";
            else if (number == 2)
                return "R2";
            else if (number == 3)
                return "L";
            else if (number == 4)
                return "L'";
            else if (number == 5)
                return "L2";
            else if (number == 6)
                return "F";
            else if (number == 7)
                return "F'";
            else if (number == 8)
                return "F2";
            else if (number == 9)
                return "B";
            else if (number == 10)
                return "B'";
            else if (number == 11)
                return "B2";
            else if (number == 12)
                return "U";
            else if (number == 13)
                return "U'";
            else if (number == 14)
                return "U2";
            else if (number == 15)
                return "D";
            else if (number == 16)
                return "D'";
            else
                return "D2";
        }

        static void GenScr(int countOfScrambles, int countOfTurns)
        {
            Cube[] scrambledCubes = new Cube[countOfScrambles];
            string[,] scrambles = new string[countOfScrambles, countOfTurns];
            string[] pythonScrambles = new string[countOfScrambles];
            Random random = new Random();
            for (int i = 0; i < countOfScrambles; i++)
            {
                scrambledCubes[i] = new Cube();
                ResetCube(ref scrambledCubes[i]);
                for(int j = 0; j < countOfTurns; j++)
                {
                    int turn = random.Next(18);
                    if (j == 0)
                    {
                        scrambles[i, j] = IntToMove(turn);
                        Drive(IntToMove(turn), ref scrambledCubes[i], false);
                    }

                    else if(scrambles[i, j - 1][0] != IntToMove(turn)[0])
                    {
                        scrambles[i, j] = IntToMove(turn);
                        Drive(IntToMove(turn), ref scrambledCubes[i], false);
                    }

                    else
                    {
                        if(18 - turn > 3)
                            turn += random.Next(3, 18 - turn);
                        else
                            turn -= random.Next(3, turn);
                        scrambles[i, j] = IntToMove(turn);
                        Drive(IntToMove(turn), ref scrambledCubes[i], false);
                    }

                    Console.Write(scrambles[i, j] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
            for(int i = 0; i < scrambledCubes.Length; i++)
            {
                Console.WriteLine(CubeToPythonString2(ref scrambledCubes[i]));
            }
            Console.WriteLine();
            for (int i = 0; i < scrambledCubes.Length; i++)
            {
                Console.Write(CubeToPythonString2(ref scrambledCubes[i]) + " ");
            }
        }

        static void Main(string[] args)
        {
            Cube cube = new Cube();
            ResetCube(ref cube);
            PrintCube(ref cube);
            for(; ; )
            {
                PrintCube(ref cube);
                string choise = Console.ReadLine();
                Console.Clear();
                if(choise == "Reset")
                {
                    ResetCube(ref cube);
                }
                else if(choise == "Drive")
                {
                    Console.WriteLine("Please, enter the turns");
                    for(; ; )
                    {
                        string turns = Console.ReadLine();
                        if(turns == "Stop")
                        {
                            break;
                        }
                        Drive(turns, ref cube, false);
                        PrintCube(ref cube);
                    }
                }
                else if (choise == "DriveBySteps")
                {
                    Console.WriteLine("Please, enter the turns");
                    for (; ; )
                    {
                        string turns = Console.ReadLine();
                        if (turns == "Stop")
                        {
                            break;
                        }
                        Drive(turns, ref cube, true);
                        PrintCube(ref cube);
                    }
                }
                else if(choise == "ToPy")
                {
                    Console.WriteLine(ToPythonString(ref cube));
                    Console.ReadLine();
                }
                else if (choise == "ToPy2")
                {
                    Console.WriteLine(CubeToPythonString2(ref cube));
                    Console.ReadLine();
                }
                else if(choise == "GenScr")
                {
                    Console.Clear();
                    Console.WriteLine("how many scrambles do you want?");
                    int scrCount = int.Parse(Console.ReadLine());
                    Console.WriteLine("how many moves may be in scrambles?");
                    int movCount = int.Parse(Console.ReadLine());
                    GenScr(scrCount, movCount);
                    Console.ReadLine();
                }
            }
        }
    }
}
