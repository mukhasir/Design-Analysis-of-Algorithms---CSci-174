using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BayBridges
{
    class my_point
    {
        private double X;
        public double x
        {
            get { return X; }
            set { X = value; }
        }
        private double Y;
        public double y
        {
            get { return Y; }
            set { Y = value; }
        }
    }
    class my_bridge
    {
        private int ID;
        public int id
        {
            get { return ID; }
            set { ID = value; }
        }
        public my_point p1 { get; set; }
        public my_point p2 { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<my_bridge> Bridges = new List<my_bridge>();
            List<my_bridge> safe = new List<my_bridge>();
            List<my_bridge> rejected = new List<my_bridge>();
            my_bridge Bridge = null;
            int count = 0;
            foreach (string LineData in File.ReadLines(@"E:\Fall 2015\Design Analysis of Algorithms\Assignment 3\Text_Data_1.txt"))
            {
                if (LineData != "")
                {
                    string[] Data = LineData.Split(':');
                    string[] GetIndexs = Data[1].Replace("([", "").Replace("])", "").Replace("], [", ",").Split(',');
                    Bridge = new my_bridge();
                    Bridge.id = Convert.ToInt32(Data[0]);
                    Bridge.p1 = new my_point();
                    Bridge.p1.x = Convert.ToDouble(GetIndexs[0].Trim());
                    Bridge.p1.y = Convert.ToDouble(GetIndexs[1].Trim());
                    Bridge.p2 = new my_point();
                    Bridge.p2.x = Convert.ToDouble(GetIndexs[2].Trim());
                    Bridge.p2.y = Convert.ToDouble(GetIndexs[3].Trim());
                    Bridges.Add(Bridge);
                }
            }
            while (Bridges.Count > 0)
            {
                int max_intersections = 0;
                my_bridge max_bridge = null;
                foreach (my_bridge bridgeValue in Bridges)
                {
                    count = bridge_intersect_count(bridgeValue, Bridges);
                    if (count == 0)
                    {
                        safe.Add(bridgeValue);
                    }
                    else if (count > max_intersections)
                    {
                        max_intersections = count;
                        max_bridge = bridgeValue;
                    }
                }
                if (max_bridge != null)
                {
                    Bridges.Remove(max_bridge);
                    rejected.Add(max_bridge);
                }
                foreach (my_bridge FBridge in safe)
                {
                    if (Bridges.Contains(FBridge))
                    {
                        Bridges.Remove(FBridge);
                    }
                }
            }
            print_bridge_numbers(safe);
        }
        public static bool ccw(my_point A, my_point B, my_point C)
        {
            return (C.y - A.y) * (B.x - A.x) > (B.y - A.y) * (C.x - A.x);
        }
        public static bool intersect(my_point A, my_point B, my_point C, my_point D){
	            return ((ccw(A,C,D) != ccw(B,C,D)) && (ccw(A,B,C) != ccw(A,B,D)));
        }
        public static void print_bridges(List<my_bridge> bridges)
        {
            foreach(my_bridge bridge in bridges)
            {
                Console.WriteLine(bridge);
            }
        }
        public static void print_bridge_numbers(List<my_bridge> bridges)
        {
            List<int> numbers = new List<int>();
            foreach (my_bridge bridge in bridges)
            {
                numbers.Add(bridge.id);
            }
            numbers.Sort();
            foreach(int n in numbers)
            {
                Console.WriteLine(n);
            }
        }
        public static int bridge_intersect_count(my_bridge br1, List<my_bridge> bridges)
        {
            int count = 0 ;
            foreach(my_bridge br2 in bridges)
            {
                if(br1.id == br2.id)
                {
                    continue;
                }
                if(intersect(br1.p1,br1.p2,br2.p1,br2.p2))
                {
                    count += 1;
                }
            }
            return count;
        }
    }
}
