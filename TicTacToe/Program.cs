
class TicTacToe
{
    static char[,] board = {
        { '1', '2', '3' },
        { '4', '5', '6' },
        { '7', '8', '9' }
    };
    static char playerSymbol, computerSymbol;

    static void Main()
    {
        ChooseSymbol();
        ChooseComputerSymbol();

        while (true)
        {
            Console.Clear();
            PrintBoard();
            PlayerMove();
            if (CheckWin(playerSymbol))
            {

                PrintBoard();
                Console.WriteLine("You win!");
                NewGame();
                break;

            }
            if (IsBoardFull())
            {
                PrintBoard();
                Console.WriteLine("draw!");
                NewGame();
                break;
            }

            ComputerMove();
            if (CheckWin(computerSymbol))
            {
                PrintBoard();
                Console.WriteLine("Computer win!");
                NewGame();
                break;
            }
            if (IsBoardFull())
            {
                PrintBoard();
                Console.WriteLine("draw!");
                NewGame();
                break;
            }
        }
    }

    static void ResetBoard()
    {
        char[,] newBoard = {
            { '1', '2', '3' },
            { '4', '5', '6' },
            { '7', '8', '9' }
        };
        Array.Copy(newBoard, board, newBoard.Length);
        // метод який копіює з одного масиву в інший перший параметр це що копіюємо другий куди третій яку кількість 
    }

    static void NewGame()
    {
        Console.WriteLine("Start new game? (yes/no):");
        string answ = Console.ReadLine();
        if (answ.ToLower() == "yes")
        {
            ResetBoard();
            Main();
        }
        else if (answ.ToLower() == "no")
        {
            Console.WriteLine("Thank you for the game");
        }
        else
        {
            Console.WriteLine("You entered something wrong");
        }
    }

    static void ChooseSymbol()
    {
        Console.Write("Choose a symbol (X or O): ");
        playerSymbol = Console.ReadLine()[0];

    }

    static char ChooseComputerSymbol()
    {
        if (playerSymbol == 'X' || playerSymbol == 'O')
        {
            computerSymbol = (playerSymbol == 'X') ? 'O' : 'X';

        }
        else
        {
            Console.WriteLine("Error! You must select only X or O. Or you must enter an uppercase character.");
        }
        return computerSymbol;
    }

    static void PrintBoard()
    {
        Console.Clear();
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(board[i, j]);
                if (j < 2) Console.Write(" | ");
            }
            Console.WriteLine();
            if (i < 2) Console.WriteLine("--|---|--");
        }
    }

    static void PlayerMove()
    {
        while (true)
        {
            Console.Write("Your turn(choose number of cell): ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int move) && move >= 1 && move <= 9)
            {
                int row = (move - 1) / 3;
                int col = (move - 1) % 3;
                if (board[row, col] != 'X' && board[row, col] != 'O')
                {
                    board[row, col] = playerSymbol;
                    break;
                }
            }
            Console.WriteLine("Incorect choose. Try another nomber.");
        }
    }

    static void ComputerMove()
    {
        Random random = new Random();

        while (true)
        {
            int i = random.Next(0, 3);
            int j = random.Next(0, 3);

            if (board[i, j] != 'X' && board[i, j] != 'O')
            {
                board[i, j] = computerSymbol;
                return;
            }
        }

    }


    static bool CheckWin(char symbol)
    {
        for (int i = 0; i < 3; i++)
        {
            if ((board[i, 0] == symbol && board[i, 1] == symbol && board[i, 2] == symbol) ||
                (board[0, i] == symbol && board[1, i] == symbol && board[2, i] == symbol))
            {
                return true;

            }
            else if ((board[0, 0] == symbol && board[1, 1] == symbol && board[2, 2] == symbol) ||
                    (board[0, 2] == symbol && board[1, 1] == symbol && board[2, 0] == symbol))
            {
                return true;
            }
        }


        return false;
    }

    static bool IsBoardFull()
    {
        foreach (char cell in board)
        {
            if (cell != 'X' && cell != 'O')
                return false;
        }
        return true;
    }
}