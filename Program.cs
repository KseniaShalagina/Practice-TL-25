using System.ComponentModel.Design;
using System.Diagnostics;
using System.Xml.Linq;

Menu();

static void Menu()
{
    Console.WriteLine("1. Начать заказ");
    Console.WriteLine("2. Выход");
    Console.Write("Выберете пункт: ");
    string choiceStr = Console.ReadLine();
    int choice = int.Parse(choiceStr);
    switch (choice)
    {
        case 1:
            Order();
            break;

        case 2:
            Console.WriteLine("До свидания!");
            break;
        default:
            throw new Exception($"Неизвестная ошибка с : {choice}");
    }
}
static void Order()
{
    string name = Input("Пожалуйста, введите ваше имя: ");
    string product = Input("Пожалуйста, введите название товара: ");
    int counts = InputCount("Пожалуйста, укажите количество товара: ");
    string address = Input("Пожалуйста, введите адресс доставки: ");
    DateTime dateOrder = DateTime.Now;
    OrderCorrect(name, counts, product, address);
    Check(name, counts, product, address, dateOrder);
}
static void OrderCorrect(string name, int count, string product, string address)
{
    Console.WriteLine($"Здравствуйте, {name} , вы заказали {count} {product} на адрес {address}, все верно?");
}

static string Input(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        string inputStr = Console.ReadLine();

        if (!string.IsNullOrEmpty(inputStr))
        {
            return inputStr;
        }

        Console.WriteLine("Неккорректный ввод данных! Попробуйте ещё раз!");
        Console.WriteLine("");
    }
}

static int InputCount(string s)
{

    while (true)
    {
        Console.Write(s);
        var operand = Console.ReadLine();
        bool isResult = int.TryParse(operand, out int result);
        if (isResult && result > 0)
        {
            return result;
        }
        Console.WriteLine("Неккорректный ввод данных! Попробуйте ещё раз!");
        Console.WriteLine("");
    }
}


static void Check(string name, int count, string product, string address, DateTime dateOrder)
{
    Console.Write("В случает верности заказала ввестите 'Да', иначе любое сочетание скавиш: ");
    string check = Console.ReadLine();
    if (check == "Да")
    {
        Console.WriteLine($"{name}! Ваш заказ {product} в количестве {count} оформлен! Ожидайте доставку по адресу {address} к {dateOrder.AddDays(3)}");
    }
    else
    {
        Console.WriteLine($"Заказ отменён! {name}, до свидания!");
    }
}
