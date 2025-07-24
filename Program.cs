Menu();
static void Menu()
{
    Console.WriteLine( "1. Начать заказ" );
    Console.WriteLine( "2. Выход" );
    int choice = ReadPositiveNumber( "Выберете пункт: " );
    switch ( choice )
    {
        case 1:
            Order();
            break;

        case 2:
            Console.WriteLine( "До свидания!" );
            break;
        default:
            Console.WriteLine( $"Вы ввели некорpектное значение : {choice}" );
            break;
    }
}
static void Order()
{
    string name = ReadString( "Пожалуйста, введите ваше имя: " );
    string product = ReadString( "Пожалуйста, введите название товара: " );
    int counts = ReadPositiveNumber( "Пожалуйста, укажите количество товара: " );
    string address = ReadString( "Пожалуйста, введите адресс доставки: " );
    DateTime deliveryDate = DateTime.Now.AddDays( 3 );
    ConfirmOrder( name, counts, product, address, deliveryDate );
}
static string ReadString( string prompt )
{
    while ( true )
    {
        Console.Write( prompt );
        string inputStr = Console.ReadLine();

        if ( !string.IsNullOrEmpty( inputStr ) )
        {
            return inputStr;
        }

        Console.WriteLine( "Неккорректный ввод данных! Попробуйте ещё раз!" );
        Console.WriteLine( "" );
    }
}

static int ReadPositiveNumber( string сhecKNumber )
{

    while ( true )
    {
        Console.Write( сhecKNumber );
        var operand = Console.ReadLine();
        bool isResult = int.TryParse( operand, out int result );
        if ( isResult && result > 0 )
        {
            return result;
        }
        Console.WriteLine( "Неккорректный ввод данных! Попробуйте ещё раз!" );
        Console.WriteLine( "" );
    }
}


static void ConfirmOrder( string name, int count, string product, string address, DateTime deliveryDate )
{
    Console.WriteLine( $"Здравствуйте, {name} , вы заказали {count} {product} на адрес {address}, все верно?" );
    Console.Write( "В случает верности заказала ввестите 'Да', иначе любое сочетание скавиш: " );
    string check = Console.ReadLine();
    if ( check == "Да" )
    {
        Console.WriteLine( $"{name}! Ваш заказ {product} в количестве {count} оформлен! Ожидайте доставку по адресу {address} к {deliveryDate}" );
    }
    else
    {
        Console.WriteLine( $"Заказ отменён! {name}, до свидания!" );
    }
}
