using CasinoMy;
const string GameName = @"
   ####   ##    ####  ####  #  #  ####
   #     #  #  #       ##   #  #  #  #
   #     ####   ####   ##   ####  #  #
   #     #  #      #   ##   #  #  #  #
   ####  #  #  ####   ####  #  #  ####";

PrintGameName(GameName);
static void PrintGameName(string GameName)
{
    Console.WriteLine(GameName);
}
Console.Write("Введите начальный баланс: ");
string balanseStr = Console.ReadLine();
bool isBanaseParsed = int.TryParse(balanseStr, out int balance);
if (!isBanaseParsed)
{
    Console.WriteLine($"Не кореектно введен баланс: {balanseStr}");
    return;
}

if (balance <= 0)
{
    Console.WriteLine("игра окончена, отрицательный баланс");
    return;
}
Console.WriteLine($"Баланс: {balance}");

const int multiplicator = 1;



Operations? operation = Operations.Initial;

while (operation != Operations.Exit&&operation!=null&&balance>0)
{
    operation = ReadOperations();
    HendleOperation(operation.Value, ref balance);
}
static Operations? ReadOperations()
{
    Console.WriteLine("Menu");
    Console.WriteLine("1 - Начать игру");
    Console.WriteLine("2 - Проверить баланс");
    Console.WriteLine("3 - Выход");
    Console.Write("Ваш выбор: ");
    string operationStr = Console.ReadLine();
    bool isParsed = Enum.TryParse(operationStr, out Operations operations);

    return isParsed ? operations : null;
}

static void HendleOperation(Operations operation, ref int balance)
{

    switch (operation)
    {
        case Operations.Initial:
            return;
        case Operations.Play:

            Game(ref balance);
            break;
        case Operations.CheckBalance:
            CheckBalanse(balance);
            break;
        case Operations.Exit:
            Console.WriteLine("До свидания!");
            break;
        default:
            throw new Exception($"unsuputtid operation: {operation}");
            break;
    }
}
static bool CheckBalanse(int balance)
{
    Console.WriteLine($"Ваш баналс: {balance}");
    if (balance > 0)
    {
        Console.WriteLine("Вы можете продолжать игру");
        return true;
    }
    else
    {
        Console.WriteLine("Ваш баланс отрицательный, для вас игра окончена");
        return false;
    }
}
static int InputBet()
{
    Console.Write("Введите ставку: ");
    string betStr = Console.ReadLine();
    bool isBetParsed = int.TryParse(betStr, out int bet);
    if (!isBetParsed || bet <= 0)
    {
        Console.WriteLine($"Не кореектно введен баланс: {betStr}");
        throw new Exception($"Invalid bet value: {bet}");

    }

    Console.WriteLine($"Ваша ставка: {bet}");
    return bet;
}

static int Game(ref int balance)
{
    int betGame = InputBet();
    int number = RandomNumber();
    Console.WriteLine($"Выпала фишка: {number}");
    if (number < 18)
    {
        Console.WriteLine("Вы проиграли)");
        balance = balance - betGame;
    }
    else
    {
        Console.WriteLine("Вы выиграли!!!!");
        int win = betGame * (multiplicator + (1 * number % 17));
        balance = balance + win;
    }
    return balance;
}
static int RandomNumber()
{
    Random rnd = new Random();
    var randomBetween = rnd.Next(0, 21);
    return randomBetween;
}