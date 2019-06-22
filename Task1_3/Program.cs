using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Entrance to User Interface
            MainMenu();
        }

        //User Interface
        public static void MainMenu()
        {
            string path = "MainMenu";
            List<String> MainMenuOptionList= new List<string>
            {
                "1. 'Esc' - exit from the program;",
                "2. '1' - enter to UserArrayMenu;",
                "3. '2' - enter to RandomArrayMenu;",
                "4. '3' - enter to MergeSort."
            };
            ConsoleKeyInfo keyInfo;

            List<int> unsortedArray = new List<int> { };
                      
            do
            {
                ShowInfo(path, MainMenuOptionList);
                keyInfo = Console.ReadKey();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.Escape:
                        {
                            break;
                        }
                    case ConsoleKey.D1:
                        {
                            UserArrayMenu(path, ref unsortedArray);
                            break;
                        }
                    case ConsoleKey.D2:
                        {
                            RandomArrayMenu(path, ref unsortedArray);
                            break;
                        }
                    case ConsoleKey.D3:
                        {
                            MergeSortMenu(path, ref unsortedArray);
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }

            } while (keyInfo.Key != ConsoleKey.Escape);
        }

        public static void UserArrayMenu(string parentPath, ref List<int> array)
        {
            string path = parentPath + " > UserArrayMenu";
            List<string> UserArrayMenuOptionList = new List<string>
            {
                "1. 'Esc' - exit from this menu;\n" +
                "2. 'D' - delete the array;\n" +
                "3. 'B' - delete last element of the array or current value;\n" +
                "4. 'Backspace' - delete carrent value.\n"

            };
            List<ConsoleKey> numbers = new List<ConsoleKey>
            {
                ConsoleKey.D1,
                ConsoleKey.D2,
                ConsoleKey.D3,
                ConsoleKey.D4,
                ConsoleKey.D5,
                ConsoleKey.D6,
                ConsoleKey.D7,
                ConsoleKey.D8,
                ConsoleKey.D9,
                ConsoleKey.D0
            }; 
            ConsoleKeyInfo keyInfo;
            string num = "";
            
            do
            {
                ShowInfo(path, UserArrayMenuOptionList);
                if (array.Count > 0)
                {
                    for (int i = 0; i < array.Count; i++)
                    {
                        Console.Write(array[i] + " ");
                    }
                }
                Console.Write(num);
                
                keyInfo = Console.ReadKey();

                if (numbers.Any(x => x == keyInfo.Key) || keyInfo.Key == ConsoleKey.OemMinus)
                {
                    num += keyInfo.KeyChar;

                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    if (num != "")
                    {
                        try
                        {
                            array.Add(Convert.ToInt32(num));
                            num = "";
                        }
                        catch (Exception)
                        {
                            num = "";
                        }
                        
                    }                    
                }
                else if (keyInfo.Key == ConsoleKey.Backspace)
                {
                    if (num.Length > 0)
                    {
                        num = num.Remove(num.Length - 1);
                    }
                }
                else if (keyInfo.Key == ConsoleKey.B)
                {
                    if (array.Count>0 && (num == ""))
                    {
                        array.RemoveAt(array.Count - 1);
                    }
                    else if (num != "")
                    {
                        num = "";
                    }
                }
                else if (keyInfo.Key == ConsoleKey.D)
                {
                    if (array.Count > 0)
                    {
                        array.Clear();
                        num = "";
                    }
                }            

            } while (keyInfo.Key != ConsoleKey.Escape);
        }

        public static void RandomArrayMenu(string parentPath, ref List<int> array)
        {
            string path = parentPath + " > RandomArrayMenu";
            List<string> RandomArrayMenuOptionList = new List<string>
            {
                "1. 'Esc' - exit from this menu;\n" + 
                "2. 'N' - read minimum value of the array;\n3. 'M' - read maximum value of the array;\n" +
                "4. 'D' - delete the array;\n5. 'Enter' - read size of the array (1 - 1000).\n"
                
            };
            List<ConsoleKey> numbers = new List<ConsoleKey>
            {
                ConsoleKey.D1,
                ConsoleKey.D2,
                ConsoleKey.D3,
                ConsoleKey.D4,
                ConsoleKey.D5,
                ConsoleKey.D6,
                ConsoleKey.D7,
                ConsoleKey.D8,
                ConsoleKey.D9,
                ConsoleKey.D0
            };
            ConsoleKeyInfo keyInfo;
            string num = "";
            Random random = new Random();
            int min = -50, max = 50;
            do
            {
                ShowInfo(path, RandomArrayMenuOptionList);
                Console.WriteLine("minValueElementOfArray = {0}, maxValueElementOfArray = {1}", min, max);
                if (array.Count > 0)
                {
                    for (int i = 0; i < array.Count; i++)
                    {
                        Console.Write(array[i] + " ");
                    }
                }
                Console.Write("\n" + num);

                keyInfo = Console.ReadKey();

                if (numbers.Any(x => x == keyInfo.Key) || keyInfo.Key == ConsoleKey.OemMinus)
                {
                    num += keyInfo.KeyChar;

                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    if (num != "")
                    {
                        try
                        {
                            array.Clear();
                            for (int i = 0; i < Convert.ToInt32(num); i++)
                            {
                                array.Add(random.Next(min, max + 1));
                            }
                            num = "";
                        }
                        catch (Exception)
                        {
                            num = "";
                        }

                    }
                }
                else if (keyInfo.Key == ConsoleKey.D)
                {
                    if (array.Count > 0)
                    {
                        array.Clear();
                        num = "";
                    }
                }
                else if (keyInfo.Key == ConsoleKey.B)
                {
                    if (array.Count > 0 && (num == ""))
                    {
                        array.RemoveAt(array.Count - 1);
                    }
                    else if (num != "")
                    {
                        num = "";
                    }
                }
                else if (keyInfo.Key == ConsoleKey.N)
                {
                    if (num != "")
                    {
                        try
                        {
                            if (Convert.ToInt32(num) < max)
                            {
                                min = Convert.ToInt32(num);
                                num = "";
                            }
                            
                        }
                        catch (Exception)
                        {
                            num = "";
                        }
                        
                    }
                }
                else if (keyInfo.Key == ConsoleKey.M)
                {
                    if (num != "")
                    {
                        try
                        {
                            if (Convert.ToInt32(num) > min)
                            {
                                max = Convert.ToInt32(num);
                                num = "";
                            }

                        }
                        catch (Exception)
                        {
                            num = "";
                        }

                    }
                }

            } while (keyInfo.Key != ConsoleKey.Escape);
        }

        public static void MergeSortMenu(string parentPath, ref List<int> array)
        {
            string path = parentPath + " > MergeSortMenu";
            List<string> MergeSortMenuOptionList = new List<string>
            {
                "1. 'Esc' - exit from this menu;\n" +
                "2. 'Enter' - sort the array.\n"
            };
            ConsoleKeyInfo keyInfo;
            string num = "";

            do
            {
                ShowInfo(path, MergeSortMenuOptionList);
                if (array.Count > 0)
                {
                    Console.Write("Unsorted array:\n");
                    for (int i = 0; i < array.Count; i++)
                    {
                        Console.Write(array[i] + " ");
                    }
                    Console.Write("\n");
                }
                Console.Write("Sorted array:\n" + num);

                keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    num = "";
                    MergeSort(array);
                    for (int i = 0; i < MergeSort(array).Count; i++)
                    {
                        num += Convert.ToString(MergeSort(array)[i]);
                        num += " ";
                    }
                }

            } while (keyInfo.Key != ConsoleKey.Escape);
        }

        public static void ShowInfo(string path, List<string> menuOption)
        {
            Console.Clear();
            Console.WriteLine(path);
            Console.Write("\n");
            for (int i = 0; i < menuOption.Count; i++)
            {
                Console.WriteLine(menuOption[i]);
            }
            
        }

        //Merge Sort Interface
        public static List<int> MergeSort(List<int> unsorted)
        {
            List<int> sorted = new List<int> {};

            if (unsorted.Count <= 1)
            {
                sorted = unsorted;
                return sorted;
            }

            int midle = unsorted.Count / 2;

            List<int> Left = new List<int> { };
            List<int> Right = new List<int> { };

            for (int i = 0; i < midle; i++)
            {
                Left.Add(unsorted[i]);
            }

            for (int i = midle; i < unsorted.Count; i++)
            {
                Right.Add(unsorted[i]);
            }

            Left = MergeSort(Left);
            Right = MergeSort(Right);

            return Merge(Left, Right);
        }

        public static List<int> Merge(List<int> Left, List<int> Right)
        {
            List<int> result = new List<int> { };

            while (Left.Count != 0 && Right.Count != 0)
            {
                if (Left[0] >= Right[0])
                {
                    result.Add(Right[0]);
                    Right.Remove(Right[0]);
                }
                else
                {
                    result.Add(Left[0]);
                    Left.Remove(Left[0]);
                }
            }

            if (Left.Count == 0)
            {
                result.AddRange(Right);
            }
            else
            {
                result.AddRange(Left);
            }

            return result;
        }
    }
}
