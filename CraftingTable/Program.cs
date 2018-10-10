using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CraftingTable
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }
        static void Menu()
        {
            Material empty = new Material() { Number = 0 };
            Material stick = new Material() { Number = 1 };
            Material wood = new Material() { Number = 2 };
            Material stone = new Material() { Number = 3 };
            Material gold = new Material() { Number = 4 };
            Material iron = new Material() { Number = 5 };
            Material diamond = new Material() { Number = 6 };
            const int arrayLength = 9;
            Material[] tableArray = new Material[arrayLength] { empty, empty, empty, empty, empty, empty, empty, empty, empty };

            string inputString;
            int position;
            int material;
            for (int i = 0; i < arrayLength; i++)
            {
                Console.Clear();
                Write("+---+---+---+\n| " + tableArray[0].Number + " | " + tableArray[1].Number + " | " + tableArray[2].Number + " |\n+---+---+---+\n| "
                + tableArray[3].Number + " | " + tableArray[4].Number + " | " + tableArray[5].Number + " |\n+---+---+---+\n| " + tableArray[6].Number + " | "
                + tableArray[7].Number + " | " + tableArray[8].Number + " |\n+---+---+---+\n");
                WriteLine("Материалы: \n 0.Пустая ячейка\n 1.Палка\n 2.Дерево\n 3.Камень\n 4.Золото\n 5.Железо\n 6.Алмаз\n");
                WriteLine("Выберите ячейку(0 для завершения): ");
                inputString = ReadLine();
                position = int.Parse(inputString);
                if (position == 0) break;
                if (position > 9)
                {
                    Console.Clear();
                    WriteLine("Выбрана несуществующая ячейка!");
                    return;
                }
                WriteLine("Выберите материал: ");
                inputString = ReadLine();
                material = int.Parse(inputString);
                switch (material)
                {
                    case 1:
                        tableArray[position - 1] = stick;
                        break;
                    case 2:
                        tableArray[position - 1] = wood;
                        break;
                    case 3:
                        tableArray[position - 1] = stone;
                        break;
                    case 4:
                        tableArray[position - 1] = gold;
                        break;
                    case 5:
                        tableArray[position - 1] = iron;
                        break;
                    case 6:
                        tableArray[position - 1] = diamond;
                        break;
                }
            }
            Console.Clear();
            Write("+---+---+---+\n| " + tableArray[0].Number + " | " + tableArray[1].Number + " | " + tableArray[2].Number + " |\n+---+---+---+\n| "
                + tableArray[3].Number + " | " + tableArray[4].Number + " | " + tableArray[5].Number + " |\n+---+---+---+\n| " + tableArray[6].Number + " | "
                + tableArray[7].Number + " | " + tableArray[8].Number + " |\n+---+---+---+\n");

            Material arrayTotal = new Material();
            foreach (Material item in tableArray)
            {
                arrayTotal += item;
            }

            Material leftColumn = tableArray[0] + tableArray[3] + tableArray[6];
            Material middleColumn = tableArray[1] + tableArray[4] + tableArray[7];
            Material rightColumn = tableArray[2] + tableArray[5] + tableArray[8];

            Material topRow = tableArray[0] + tableArray[1] + tableArray[2];
            Material middleRow = tableArray[3] + tableArray[4] + tableArray[5];
            Material bottomRow = tableArray[6] + tableArray[7] + tableArray[8];

            Material pair1 = tableArray[0] + tableArray[1];
            Material pair2 = tableArray[1] + tableArray[2];
            Material pair3 = tableArray[0] + tableArray[3];
            Material pair4 = tableArray[1] + tableArray[4];
            Material pair5 = tableArray[2] + tableArray[5];
            Material pair6 = tableArray[3] + tableArray[4];
            Material pair7 = tableArray[4] + tableArray[5];

            if (arrayTotal.Number < 4 || arrayTotal.Number == 15 || arrayTotal.Number == 16 ||
                arrayTotal.Number == 18 || arrayTotal.Number == 19 || arrayTotal.Number > 20 || bottomRow.Number != 1)
            {
                WriteLine("Вы ничего не создали! Изучите рецепты!");
            }
            else
            {
                if ((leftColumn.Number == 4 || middleColumn.Number == 4 || rightColumn.Number == 4) && arrayTotal.Number < 9)
                {
                    if (topRow.Number == 2 && middleRow.Number == 1) WriteLine("Вы создали деревянную лопату!");
                    else if (((pair1.Number == 4 && pair2.Number == 2) || (pair1.Number == 2 && pair2.Number == 4)) && middleRow.Number == 1) WriteLine("Вы создали деревянную мотыгу!");
                    else if (((pair1.Number == 4 && pair2.Number == 2) || (pair1.Number == 2 && pair2.Number == 4)) && ((pair6.Number == 3 && pair7.Number == 1) || (pair6.Number == 2 && pair7.Number == 3))) WriteLine("Вы создали деревянный топор!");
                    else if ((pair1.Number == 4 && pair2.Number == 4) && middleRow.Number == 1) WriteLine("Вы создали деревянную кирку!");
                    else WriteLine("Вы ничего не создали! Изучите рецепты!");
                }
                else if ((leftColumn.Number == 5 || middleColumn.Number == 5 || rightColumn.Number == 5) && arrayTotal.Number < 12)
                {
                    if (topRow.Number == 3 && middleRow.Number == 1) WriteLine("Вы создали каменную лопату!");
                    else if (((pair1.Number == 6 && pair2.Number == 3) || (pair1.Number == 3 && pair2.Number == 6)) && middleRow.Number == 1) WriteLine("Вы создали каменную мотыгу!");
                    else if (((pair1.Number == 6 && pair2.Number == 3) || (pair1.Number == 3 && pair2.Number == 6)) && ((pair6.Number == 4 && pair7.Number == 1) || (pair6.Number == 3 && pair7.Number == 4))) WriteLine("Вы создали каменный топор!");
                    else if ((pair1.Number == 6 && pair2.Number == 6) && middleRow.Number == 1) WriteLine("Вы создали каменную кирку!");
                    else WriteLine("Вы ничего не создали! Изучите рецепты!");
                }
                else if ((leftColumn.Number == 6 || middleColumn.Number == 6 || rightColumn.Number == 6) && arrayTotal.Number < 15)
                {
                    if (topRow.Number == 4 && middleRow.Number == 1) WriteLine("Вы создали золотую лопату!");
                    else if (((pair1.Number == 8 && pair2.Number == 4) || (pair1.Number == 4 && pair2.Number == 8)) && middleRow.Number == 1) WriteLine("Вы создали золотую мотыгу!");
                    else if (((pair1.Number == 8 && pair2.Number == 4) || (pair1.Number == 4 && pair2.Number == 8)) && ((pair6.Number == 5 && pair7.Number == 1) || (pair6.Number == 4 && pair7.Number == 5))) WriteLine("Вы создали золотой топор!");
                    else if ((pair1.Number == 8 && pair2.Number == 8) && middleRow.Number == 1) WriteLine("Вы создали золотую кирку!");
                    else WriteLine("Вы ничего не создали! Изучите рецепты!");
                }
                else if (leftColumn.Number == 7 || middleColumn.Number == 7 || rightColumn.Number == 7)
                {
                    if (topRow.Number == 5 && middleRow.Number == 1) WriteLine("Вы создали железную лопату!");
                    else if (((pair1.Number == 10 && pair2.Number == 5) || (pair1.Number == 5 && pair2.Number == 10)) && middleRow.Number == 1) WriteLine("Вы создали железную мотыгу!");
                    else if (((pair1.Number == 10 && pair2.Number == 5) || (pair1.Number == 5 && pair2.Number == 10)) && ((pair6.Number == 6 && pair7.Number == 1) || (pair6.Number == 5 && pair7.Number == 6))) WriteLine("Вы создали железный топор!");
                    else if ((pair1.Number == 10 && pair2.Number == 10) && middleRow.Number == 1) WriteLine("Вы создали железную кирку!");
                    else if (topRow.Number == 3 && middleRow.Number == 3) WriteLine("Вы создали каменный меч!");
                    else WriteLine("Вы ничего не создали! Изучите рецепты!");
                }
                else if (leftColumn.Number == 8 || middleColumn.Number == 8 || rightColumn.Number == 8)
                {
                    if (topRow.Number == 6 && middleRow.Number == 1) WriteLine("Вы создали алмазную лопату!");
                    else if (((pair1.Number == 12 && pair2.Number == 6) || (pair1.Number == 6 && pair2.Number == 12)) && middleRow.Number == 1) WriteLine("Вы создали алмазную мотыгу!");
                    else if (((pair1.Number == 12 && pair2.Number == 6) || (pair1.Number == 6 && pair2.Number == 12)) && ((pair6.Number == 7 && pair7.Number == 1) || (pair6.Number == 6 && pair7.Number == 7))) WriteLine("Вы создали алмазный топор!");
                    else if ((pair1.Number == 12 && pair2.Number == 12) && middleRow.Number == 1) WriteLine("Вы создали алмазную кирку!");
                    else WriteLine("Вы ничего не создали! Изучите рецепты!");
                }
                else if ((leftColumn.Number == 5 || middleColumn.Number == 5 || rightColumn.Number == 5) && topRow.Number == 2 && middleRow.Number == 2) WriteLine("Вы создали деревянный меч!");
                else if ((leftColumn.Number == 9 || middleColumn.Number == 9 || rightColumn.Number == 9) && topRow.Number == 4 && middleRow.Number == 4) WriteLine("Вы создали золотой меч!");
                else if ((leftColumn.Number == 11 || middleColumn.Number == 11 || rightColumn.Number == 11) && topRow.Number == 5 && middleRow.Number == 5) WriteLine("Вы создали железный меч!");
                else if ((leftColumn.Number == 13 || middleColumn.Number == 13 || rightColumn.Number == 13) && topRow.Number == 6 && middleRow.Number == 6) WriteLine("Вы создали алмазный меч!");
            }
            ReadLine();
        }
    }
}
