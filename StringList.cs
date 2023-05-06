using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programmieren2Praktikum2
{
    internal class StringList
    {
        int anz = 0;
        Element first, last;
        
        public void Prepend(string value)
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
        public NumberList ToNumbers()
        {
            NumberList neu = new NumberList();
            Element temp = first;
            
            for (int i = 0; i < anz; i++)
            {
                double resultingNumber;
                if(double.TryParse(temp.Value, out resultingNumber))
                {
                    neu.Prepend(resultingNumber);
                }
            }
            return neu;
        }
        public string GetFirst()
        {
            Element temp = first;
            return temp.Value;
        }
        public MeasurementSeriesList ToMeasurementSeries()
        {
            MeasurementSeriesList neu = new MeasurementSeriesList();
            Element temp = first;
            NumberList neuNumbers = new NumberList();
            for(int i = 1; i < anz; i++)
            {
                double resultingNumber;
                if (double.TryParse(temp.Value, out resultingNumber))
                {
                    neuNumbers.Prepend(resultingNumber);
                }
            }
            neu.Prepend(first.Value, neuNumbers);
            return neu;
        }
        
        public IEnumerator<string> GetEnumerator()
        {
            for (Element temp = first; temp != null; temp = temp.next)
            {
                yield return temp.Value;
            }
        }
        public string this[int index]
        {
            get
            {
                if (index < 0 || index > anz)
                {
                    throw new IndexOutOfRangeException();
                }
                if (anz == 0)
                {
                    throw new InvalidOperationException();
                }
                Element temp = first;
                for (int i = 0; i < index; i++)
                {
                    temp = temp.next;
                }
                return temp.Value;
            }

        }





        class Element
        {
             string value;
             public string Value { get { return this.value; } }
             public Element next;
             public Element(string value)
             {
                  this.value = value;
             }
            
        }
    }
}
