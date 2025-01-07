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
                Console.WriteLine("Ви перемогли!");
                break;
            }
            if (IsBoardFull())
            {
                PrintBoard();
                Console.WriteLine("Нічия!");
                break;
            }

            ComputerMove();
            if (CheckWin(computerSymbol))
            {
                PrintBoard();
                Console.WriteLine("Комп'ютер переміг!");
                break;
            }
            if (IsBoardFull())
            {
                PrintBoard();
                Console.WriteLine("Нічия!");
                break;
            }
        }
    }

    static void ChooseSymbol()
    {
        Console.Write("Виберіть символ (X або O): ");
        playerSymbol = Console.ReadLine()[0];

    }

    static char ChooseComputerSymbol()
    {
        if (playerSymbol == 'X' || playerSymbol == 'O')
        {
            computerSymbol = (playerSymbol == 'X') ? 'O' : 'X';
            Console.WriteLine($"Ваш символ: {playerSymbol}");
            Console.WriteLine($"Символ комп'ютера: {computerSymbol}");
        }
        else
        {
            Console.WriteLine("Помилка! Ви повинні обрати тільки X або O. Або потрібно ввести символ з великої літери.");
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
            Console.Write("Ваш хід (виберіть номер клітинки): ");
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
            Console.WriteLine("Некоректний хід. Спробуйте ще раз.");
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
                return true;
        }
        return (board[0, 0] == symbol && board[1, 1] == symbol && board[2, 2] == symbol) ||
               (board[0, 2] == symbol && board[1, 1] == symbol && board[2, 0] == symbol);
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