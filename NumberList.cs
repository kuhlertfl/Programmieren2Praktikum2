using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Programmieren2Praktikum2
{
    internal class NumberList
    {
        int anz = 0;
        Element first, last;
        
        public void Prepend(double value)
        {
            if(first == null)
            {
                first = last = new Element(value);
            }
            else
            {
                Element neu = new Element(value);
                last.next = neu;
                last = neu;
            }
            anz++;
        }
        public void WriteAll()
        {
            Element temp = first; 
            for (int i = 0; i < anz; i++)
            {
                Console.WriteLine(temp.Value);
                temp = temp.next;
            }
        }
        public double Sum()
        {
            Element temp = first;
            double sum = 0;
            for (int i = 0; i < anz; i++)
            {
                sum += temp.Value;
                temp = temp.next;
            }
            return sum;
        }
        
        class Element
        {
            double value;
            public Element next;
            public double Value
            {
                get { return this.value; }
            }
            public Element(double value)
            {
                this.value = value;

            }
        }
    }
}
