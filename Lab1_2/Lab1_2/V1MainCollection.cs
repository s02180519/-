﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_2
{
    class V1MainCollection : IEnumerable<V1Data>
    {
        private List<V1Data> elements = new List<V1Data>();
        public int count = 0;

        public void Add(V1Data item)
        {
            elements.Add(item);
            count++;
        }

        public bool Remove(string id, DateTime dateTime)
        {
            bool flag = false;
            for (int i = 0; i < elements.Count; i++)
            {
                if (String.Compare(elements[i].data, id) == 0 && DateTime.Compare(elements[i].date, dateTime) == 0)
                {
                    elements.RemoveAt(i);
                    if (!flag) { flag = true; }
                }
            }
            return flag;
        }

        public void AddDefaults()
        {
            Random rnd = new Random();
            Grid new_grid;
            V1DataOnGrid value1;
            V1DataCollection value2;
            for (int i = 0; i < 3; i++)
            {
                new_grid = new Grid(rnd.Next(100), rnd.Next(5), rnd.Next(20));
                value1 = new V1DataOnGrid(Convert.ToString(i * 2), DateTime.UtcNow, new_grid);
                Add(value1);
                value2 = new V1DataCollection(Convert.ToString(i * 2 + 1), DateTime.UtcNow);
                Add(value2);
            }
        }

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < count; i++)
            {
                str = str + elements[i].ToString() + "\n";
            }
            return str;
        }

        public IEnumerator<V1Data> GetEnumerator()
        {
            return ((IEnumerable<V1Data>)elements).GetEnumerator();
        }


        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ((System.Collections.IEnumerable)elements).GetEnumerator();
        }
    }
}
