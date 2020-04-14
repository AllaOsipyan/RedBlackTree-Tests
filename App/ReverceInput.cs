using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class ReverceInput
    {
        public static void Input(TreeAlgorithm tree)
        {
            string help = "1 x - Add(x)\n2 x - Delete(x)\n3 x - Find(x)\n4   - Min()\n5   - Max()\n6 x - FindNext(x)\n7 x - FindPrevious(x)";
            Console.WriteLine(help);
            var button = Console.ReadLine();
            while (true)
            {
                if (button == "") Console.WriteLine("Line is Empty");
                else
                    if (button == "help") Console.WriteLine('\n' + help);
                    else
                    switch (button[0])
                    {
                        case '1':
                            try
                            {
                                tree.Add(Convert.ToDouble((button.Split(' ')[1])));
                                PrintOfTree.Print(tree.Root);
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Incorrect expression with Add(x)");
                            }

                            break;
                    }
                button = Console.ReadLine();
            }
        }
    }
}
