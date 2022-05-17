using System;
using System.Collections.Generic;
using System.Text;
namespace zavd1
{
    class Program
    {
        //Створити об'єкт класу Дерево, використовуючи класи Лист, Гілка. Методи: зацвісти, опасти листю, покритися інеєм, пожовтіти листю.
        static void Main(string[] args)
        {
            Leaf l1 = new ("Lystok 1");
            Leaf l2 = new ("Lystok 2");
            Leaf l3 = new ("Lystok 3");
            Leaf l4 = new ("Lystok 4");

            Branch<Leaf> b1 = new ("Vitka 1");
            Branch<Leaf> b2 = new ("Vitka 2");

            Tree<Branch<Leaf>> t1 = new ("Derevo 1");

            b1.getHashSet().Add(l1);
            b1.getHashSet().Add(l2);
            b1.getHashSet().Add(l3);
            b2.getHashSet().Add(l4);
                            
            t1.getHashSet().Add(b1);
            t1.getHashSet().Add(b2);

            t1.PokrytysIniem();
            t1.Zacvisty();

            foreach(Branch<Leaf> b in t1.getHashSet())
            {
                foreach(Leaf l in b.getHashSet())
                {
                    l.Opasty();
                }
            }

            foreach (Branch<Leaf> b in t1.getHashSet())
            {
                foreach (Leaf l in b.getHashSet())
                {
                    l.Pozhovtity();
                }
            }
           // Console.WriteLine(l1.GetHashCode());
        }
    }
    public class Leaf
    {
        private String text;

        public Leaf(String text)
        {
            this.text = text;
        }

        public void Opasty()
        {
            Console.WriteLine($"{text} opav");
        }
        public void Pozhovtity()
        {
            Console.WriteLine($"{text} pozhovtiv");
        }

        public bool Equals(Leaf obj)
        {
            if(obj==null)
            {
                return false;
            }
            return obj.text == text;
        }
        public override int GetHashCode()
        {
            return text.GetHashCode();
        }


        public override string ToString()
        {
            return text;
        }
    }
    public class Branch<T>
    {
        
        private string text;
        private HashSet<T> list;

        public Branch(string text)
        {
            this.text = text;
            list = new HashSet<T>();
        }

        

        public HashSet<T> getHashSet()
        {
            return list;
        }

        public bool Equals(Branch<T> obj)
        {
            if (obj == null)
            {
                return false;
            }
            return obj.text == text;
        }
        public override int GetHashCode()
        {
            return text.GetHashCode();
        }

        public override string ToString()
        {
            return text;
        }
    }
    public class Tree<T>
    {
        private string text;
        private HashSet<T> list;

        public Tree(string text)
        {
            this.text = text;
            list = new HashSet<T>();
        }

        public void Zacvisty()
        {
            Console.WriteLine("Derevo cvite");
        }
        public void PokrytysIniem()
        {
            Console.WriteLine("Derevo pokrulos ininem");
        }

        public bool Equals(Tree<T> obj)
        {
            if (obj == null)
            {
                return false;
            }
            return obj.text == text;
        }
        public override int GetHashCode()
        {
            return text.GetHashCode();
        }
        public override string ToString()
        {
            return text;
        }

        public HashSet<T> getHashSet()
        {
            return list;
        }

        
    }
}
