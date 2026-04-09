using Lab7Node;

public class UsageOfNodes
{
    static void Main()
    {
        try
        {
            NodeList list = new NodeList();

            Console.WriteLine("Введіть початковий масив даних для запису у список через пробіл");
            string[] initialDataStringArray = Console.ReadLine().Split(" ");

            short[] initialDataArray = new short[initialDataStringArray.Length];
            int count = 0;

            for (int i = 0; i < initialDataStringArray.Length; i++)
            {
                if (short.TryParse(initialDataStringArray[i], out short temp))
                {
                    initialDataArray[count] = temp;
                    count++;
                }
                else
                {
                    Console.WriteLine($"{initialDataStringArray[i]} не є типом даних short і не був доданий до списку");
                }
            }

            Array.Resize(ref initialDataArray, count);
            foreach (short item in initialDataArray)
            {
                list.addNext(item);
            }
            Console.WriteLine("Ваш початковий список:" + string.Join(", ", initialDataArray));

            Console.WriteLine("Введіть номер бажаної процедури\n 1 - знаходження елементу\n 2 - Пошук кратних елеметів\n 3 - Заміна елементів індекс яких є парним числом\n 4 - видалення елементів на непарних позиціях\n 5 - Додавання елементу у кінець списку\n 6 - Видалення елементу по індексу");
            if (int.TryParse(Console.ReadLine(), out int idOfProcedure) && idOfProcedure < 7 && idOfProcedure > 0)
            {

            }
            else
            {
                Console.WriteLine("Некоректний ввід номеру процедури, номер повинен бути цілочисельним числом в межах [1;4]");
            }

            switch (idOfProcedure)
            {
                case 1:
                    findIndex(list);
                    break;
                case 2:
                    findDivisors(list);
                    break;
                case 3:
                    ReplaceEvenElements(list);
                    break;
                case 4:
                    RemovingOddElements(list);
                    break;
                case 5:
                    AddElementToTheEnd(list);
                    break;
                case 6:
                    RemoveElement(list);
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Помилка. Текст помилки:" + ex.Message);
        }
    }

    public static void findIndex(NodeList list)
    {
        Console.WriteLine("Введіть індекс для знаходження елементу");
        if (int.TryParse(Console.ReadLine(), out int index))
        {
            Console.WriteLine(list[index]);
        }
        else
        {
            Console.WriteLine("Некоректний ввід індексу, індекс повинен бути цілочисельним числом");
        }
    }

    public static void findDivisors(NodeList list)
    {
        Console.WriteLine("Введіть дільник для пошуку чисел кратних йому");
        if (short.TryParse(Console.ReadLine(), out short divisor))
        {
            short? multiple = list.findMultipleBy(divisor);
            if (multiple != null)
            {
                Console.WriteLine($"Перший елемент, кратний {divisor} - {multiple.Value}");
            }
            else
            {
                Console.WriteLine($"Елемент кратний {divisor} не знайдено.");
            }
        }
        else
        {
            Console.WriteLine("Введене некоректне значення дільника");
        }
    }

    public static void ReplaceEvenElements(NodeList list)
    {
        Console.WriteLine("Введіть число для заміни елементів індекс яких є парним числом, за замовченням нуль (початковий список не буде змінюватися)");

        string replaceArgument = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(replaceArgument))
        {
            list.replaceEvenNodesToArgument();
        }
        else
        {
            if (short.TryParse(replaceArgument, out short parsedReplaceArgument))
            {
                list.replaceEvenNodesToArgument(parsedReplaceArgument);
                Console.WriteLine("Ваш список із заміною елементів з парних індексом на інше значення:" + string.Join(", ", list));
            }
        }
    }

    public static void RemovingOddElements(NodeList list)
    {
        Console.WriteLine("Автоматичне видалення елементів на непарних позиціях на копії списку");
        list.deleteOddNodes();
        Console.WriteLine("Ваш список з видаленням елементів з непарними індексами:" + string.Join(", ", list));
    }

    public static void AddElementToTheEnd(NodeList list)
    {
        Console.WriteLine("Введіть значення елементу для додавання у кінець");
        if (short.TryParse(Console.ReadLine(), out short data))
        {
            Console.WriteLine("Ваш список до додавання:" + string.Join(", ", list));
            list.addNext(data);
            Console.WriteLine("Ваш список після додавання:" + string.Join(", ", list));
        }
    }

    public static void RemoveElement(NodeList list)
    {
        Console.WriteLine("Введіть індекс елементу для видалення");
        if (int.TryParse(Console.ReadLine(), out int index))
        {
            Console.WriteLine($"Ваш список до видалленя елементу з індексом {index}:" + string.Join(", ", list));
            list.RemoveElement(index);
            Console.WriteLine($"Ваш список після видаленняелементу з індексом {index}:" + string.Join(", ", list));

        }
    }
}