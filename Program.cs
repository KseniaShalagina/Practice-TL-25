using CasinoMy;
class Program
{
    static void Main( string[] args )
    {
        const string GameName = @"
    ####   ##    ####  ####  #  #  ####
    #     #  #  #       ##   #  #  #  #
    #     ####   ####   ##   ####  #  #
    #     #  #      #   ##   #  #  #  #
    ####  #  #  ####   ####  #  #  ####";
        const int multiplicator = 1;
        PrintGameName( GameName );
        int balance = GetBalance();
        Console.WriteLine( $"Баланс: {balance}" );
        Operations? operation = Operations.Initial;
        while ( operation != Operations.Exit && balance > 0 )
        {
            operation = ReadOperations();
            balance = HandleOperation( operation.Value, balance, multiplicator );
        }
    }
    static int GetBalance()
    {
        Console.Write( "Введите начальный баланс: " );
        string balanceStr = Console.ReadLine();
        bool isBanaseParsed = int.TryParse( balanceStr, out int balance );
        if ( !isBanaseParsed )
        {
            Console.WriteLine( $"Не кореектно введен баланс: {balanceStr}" );
            return 0;
        }
        else
        {
            return balance;
        }
    }
    static void PrintGameName( string GameName )
    {
        Console.WriteLine( GameName );
    }
    static Operations? ReadOperations()
    {
        Console.WriteLine( "Menu" );
        Console.WriteLine( "1 - Начать игру" );
        Console.WriteLine( "2 - Проверить баланс" );
        Console.WriteLine( "3 - Выход" );
        Console.Write( "Ваш выбор: " );
        string operationStr = Console.ReadLine();
        bool isParsed = Enum.TryParse( operationStr, out Operations operations );
        return isParsed ? operations : null;
    }
    static int HandleOperation( Operations operation, int balance, int multiplicator )
    {
        switch ( operation )
        {
            case Operations.Initial:
                return balance;
            case Operations.Play:
                balance = PlayGame( balance, multiplicator );
                break;
            case Operations.CheckBalance:
                CheckBalance( balance );
                break;
            case Operations.Exit:
                Console.WriteLine( "До свидания!" );
                break;
            default:
                Console.WriteLine( $"Unsuputtid operation: {operation}" );
                break;
        }
        return balance;
    }
    static int CheckBalance( int balance )
    {
        Console.WriteLine( $"Ваш баланс: {balance}" );
        if ( balance > 0 )
        {
            Console.WriteLine( "Вы можете продолжать игру" );
            return balance;
        }
        else
        {
            Console.WriteLine( "Ваш баланс отрицательный, для вас игра окончена" );
            return 0;
        }
    }
    static int InputBet()
    {
        while ( true )
        {
            Console.Write( "Введите ставку: " );
            string betStr = Console.ReadLine();
            bool isBetParsed = int.TryParse( betStr, out int bet );
            if ( isBetParsed && bet > 0 )
            {
                Console.WriteLine( $"Ваша ставка: {bet}" );
                return bet;
            }
            else
            {
                Console.WriteLine( $"Некорректно введен баланс: {betStr}" );
                Console.WriteLine( $"Invalid bet value: {bet}" );
            }
        }
    }
    static int PlayGame( int balance, int multiplicator )
    {
        int betGame = InputBet();
        int number = GetRandomNumber();
        Console.WriteLine( $"Выпала фишка: {number}" );
        if ( number < 18 )
        {
            Console.WriteLine( "Вы проиграли)" );
            balance = balance - betGame;
        }
        else
        {
            Console.WriteLine( "Вы выиграли!!!!" );
            int win = betGame * ( multiplicator + ( 1 * number % 17 ) );
            balance = balance + win;
        }
        return balance;
    }
    static int GetRandomNumber()
    {
        Random rnd = new Random();
        var randomBetween = rnd.Next( 0, 21 );
        return randomBetween;
    }
}