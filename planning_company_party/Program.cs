using System;

namespace planning_company_party
{
    class Program
    {
        public class Node
        {

            public string name;
            public int conviviality;
            public Node right_sibling;
            public Node left_child;
            public Node parent;
            public int a;
            public int p;
            public Boolean guest;

            Node root;
            public void Set_root(Node x)
            {
                root = x;
            }

            public void Calc_max(Node x)
            {                
                x.a = 0; x.p = x.conviviality;
                
                Node y = x.left_child;
                while (y != null)
                {
                    Calc_max(y);
                    y = y.right_sibling;
                }

                if (x != root)
                {
                    x.parent.a += Math.Max(x.a, x.p);                    
                    x.parent.p += x.a;
                    
                }              
            }

            public int List_guest(Node x)
            {
                int max = 0;
                if (x == root)
                {
                    if (x.p > x.a)
                    {
                        x.guest = true;
                        Console.WriteLine(x.name + " " + x.conviviality+" "+x.a+" "+x.p);
                        max = x.conviviality;
                    }
                    else
                        x.guest = false;
                }
                else 
                {
                    if (x.parent.guest == true)
                        x.guest = false;
                    else
                    {
                        if (x.p > x.a)
                        {
                            x.guest = true;
                            Console.WriteLine(x.name + "\t\t" + x.conviviality + "\t\t" + x.a + "\t\t" + x.p);
                            max = x.conviviality;
                        }
                        else
                            x.guest = false;
                    }
                }
                Node y = x.left_child;
                while (y != null)
                {                    
                    max += List_guest(y);
                    y = y.right_sibling;
                }
                
                return max;
            }
        }

        static void Main(string[] args)
        {
            Node r = new Node();
            Node n1 = new Node(), n2 = new Node(), n3 = new Node();
            Node n4 = new Node(), n5 = new Node(), n6 = new Node(), n7 = new Node(), n8 = new Node(), n9 = new Node(), n10 = new Node(), n11 = new Node();
            Node n12 = new Node(), n13 = new Node(), n14 = new Node();

            //tree structut of the organization

            r.name = "r \t\t Ayub"; //r is root oof the tree
            r.conviviality = 6;
            r.left_child = n1;
            r.right_sibling = null;

            n1.parent = r;
            n1.name = "n1\t\tMirza";
            n1.conviviality = 15;
            n1.right_sibling = n2;
            n1.left_child = n4;
            

            n2.parent = r;
            n2.name = "n2\t\tKashan";
            n2.conviviality = 9;
            n2.left_child = n6;

            n2.right_sibling = n3;

            n3.parent = r;
            n3.name = "n3\t\tSaad";
            n3.conviviality = 12;
            n3.left_child = n10;

            n4.parent = n1;
            n4.name = "n4\t\tQazi";
            n4.conviviality = 6;
            n4.right_sibling = n5;

            n5.parent = n1;
            n5.name = "n5\t\tBilal";
            n5.conviviality = 4;
            n5.left_child = n12;

            n6.parent = n2;
            n6.name = "n6\t\tWaqar";
            n6.conviviality = 6;
            n6.right_sibling = n7;

            n7.parent = n2;
            n7.name = "n7\t\tNabeel";
            n7.conviviality = 8;
            n7.right_sibling = n8;

            n8.parent = n2;
            n8.name = "n8\t\tAmir";
            n8.conviviality = 11;
            n8.right_sibling = n9;
            n8.left_child = n13;
            
            n9.parent = n2;
            n9.name = "n9\t\tAhmed";
            n9.conviviality = 16;

            n10.parent = n3;
            n10.name = "n10\t\tAtif";
            n10.conviviality = 4;
            n10.right_sibling = n11;

            n11.parent = n3;
            n11.name = "n11\t\tWaryaam";
            n11.conviviality = 5;

            n12.parent = n5;
            n12.name = "n12\t\tAkmal";
            n12.conviviality = 14;

            n13.parent = n8;
            n13.name = "n13\t\tWaleed";
            n13.conviviality = 3;
            n13.right_sibling = n14;

            n14.parent = n8;
            n14.name = "n14\t\tMajid";
            n14.conviviality = 2;

            Console.WriteLine("\t\t\t####################################################################");
            Console.WriteLine("\t\t\t\t\t\tPLAN A COMPANY PARTY");
            Console.WriteLine("\t\t\t####################################################################\n");
            Console.WriteLine("Node\t\tName\t\tConviviality\ta[x]\t\tP[x]\n");
            Node c = new Node();
            c.Set_root(r);
            c.Calc_max(r);
            int rat = c.List_guest(r);
            Console.WriteLine("\n\nmaximum sum of the conviviality ratings of the guests: " + rat);
            Console.ReadLine();
        }
    }
}
