using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Lab1_2
{
    class V1DataCollection:V1Data           /*значения поля на неравномерной сетке, которые хранятся в коллекции List<DataItem>*/
    {
        public List<DataItem> value;

        public V1DataCollection(string new_data, DateTime new_date) : base(new_data, new_date)
        {
            value = new List<DataItem>();
        }

        public override float[] NearZero(float eps)
        {
            List<float> time = new List<float>();
            for (int i = 0; i < value.Count; i++)
            {
                if (value[i].coordinates.Length() < eps)
                {
                    time.Add(value[i].t);
                }
            }
            return time.ToArray();
        }

        public void InitRandom(int nItems, float tmin, float tmax, float minValue, float maxValue)
        {
            Random rnd = new Random();
            for (int i = 0; i < nItems; i++)
            {
                value.Add(new DataItem(rnd.Next(Convert.ToInt32(tmin), Convert.ToInt32(tmax)), new Vector3(rnd.Next(Convert.ToInt32(minValue), Convert.ToInt32(maxValue)), rnd.Next(Convert.ToInt32(minValue), Convert.ToInt32(maxValue)), rnd.Next(Convert.ToInt32(minValue), Convert.ToInt32(maxValue)))));
            }
        }

        public override string ToString()
        {
            return "type is: V1DataCollection\n" + base.ToString() + value.Count + "\n";
        }

        public override string ToLongString()
        {
            return ToString() + value.ToString();
        }
    }
}
