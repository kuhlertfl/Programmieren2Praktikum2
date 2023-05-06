using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programmieren2Praktikum2
{
    internal class MeasurementSeriesList
    {
        int anz = 0;
        Element first, last;

        public void Prepend(string description, NumberList numbers)
        {
            if(first == null)
            {
                first = last = new Element(description, numbers);
            }
            else
            {
                Element neu = new Element(description, numbers);
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
                
                NumberList numberlist = temp.NumberList;
                Console.WriteLine($"{temp.Description}: \n");
                numberlist.WriteAll();
                temp = temp.next;
            }
        }
        public double Sum()
        {
            Element temp = first;
            double sum = 0;
            for (int i = 0; i < anz; i++)
            {
                sum += temp.NumberList.Sum();
                temp = temp.next;
            }
            return sum;
        }
        public StringList Descriptions()
        {
            Element temp = first;
            StringList newStringList = new StringList();

            for (int i = 0; i < anz; i++)
            {
                newStringList.Prepend(temp.Description);
                temp = temp.next;
            }
            return newStringList;
        }
        public NumberList findNumberList(string description)
        {
            Element temp = first;
            NumberList newNumberList = new NumberList();
            for (int i = 0; i < anz; i++)
            {
                if (temp.Description == description)
                {
                    newNumberList = temp.NumberList;
                }
            }
            return newNumberList;
        }
        
        class Element
        {
            string description;
            NumberList numberList;
            public Element next;
            public string Description
            {
                get { return this.description;  }
            }
            public NumberList NumberList
            {
                get { return this.numberList; }
            }
            public Element(string description, NumberList numberList)
            {
                this.description = description;
                this.numberList = numberList;
            }
        }
    }
}
