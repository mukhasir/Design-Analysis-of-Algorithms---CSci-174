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
            List<my_bridge> BridgeValues = new List<my_bridge>();
            my_bridge Bridge = null;
            foreach (string LineData in File.ReadLines(@"E:\Fall 2015\Design Analysis of Algorithms\Assignment 3\Text_Data_old.txt"))
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
                    BridgeValues.Add(Bridge);
                }
            }
            List<my_bridge> safe = new List<my_bridge>();
            List<my_bridge> rejected = new List<my_bridge>();
            while (BridgeValues.Count > 0)
            {
                int max_intersections = 0;
                my_bridge max_bridge = null;
                foreach (my_bridge Bridges in BridgeValues)
                {
                    int intrCount = bridge_intersect_count(Bridges, BridgeValues);
                    if (intrCount == 0)
                    {
                        safe.Add(Bridges);
                    }
                    else if (intrCount >= max_intersections)
                    {
                        max_intersections = intrCount;
                        max_bridge = Bridges;
                    }
                }
                BridgeValues.Remove(max_bridge);
                foreach (my_bridge SafeBridge in safe)
                {
                    BridgeValues.Remove(SafeBridge);
                }
            }
            List<int> results = new List<int>();
            foreach (my_bridge br_res in safe)
            {
                results.Add(br_res.id);
            }
            foreach (int iValue in results)
            {
                Console.WriteLine(iValue);
            }
        }
        public static int bridge_intersect_count(my_bridge br1, List<my_bridge> bridges)
        {
            int count = 0;
            foreach (my_bridge br2 in bridges)
            {
                if (br1.id == br2.id)
                    continue;
                if (my_check_intersect(br1, br2))
                {
                    count += 1;
                }
            }
            return count;
        }
        public static bool my_check_intersect(my_bridge b1, my_bridge b2)
        {
            double delt1, delt2, delt3, delt4;

            delt1 = (b2.p1.x - b1.p1.x) * (b2.p2.y - b1.p1.y) - (b2.p1.y - b1.p1.y) * (b2.p2.x - b1.p1.x);
            delt2 = (b2.p1.x - b1.p2.x) * (b2.p2.y - b1.p2.y) - (b2.p1.y - b1.p2.y) * (b2.p2.x - b1.p2.x);
            delt3 = (b1.p1.x - b2.p1.x) * (b1.p2.y - b2.p1.y) - (b1.p1.y - b2.p1.y) * (b1.p2.x - b2.p1.x);
            delt4 = (b1.p1.x - b2.p2.x) * (b1.p2.y - b2.p2.y) - (b1.p1.y - b2.p2.y) * (b1.p2.x - b2.p2.x);
            if ((delt1 > 0 && delt2 < 0) || (delt1 < 0 && delt2 > 0) && (delt3 > 0 && delt4 < 0) || (delt3 < 0 && delt4 > 0))
                return true;
            else if (delt1 == 0 && is_OnSegment(b1.p1, b2.p1, b2.p2))
                return true;
            else if (delt2 == 0 && is_OnSegment(b1.p2, b2.p1, b2.p2))
                return true;
            else if (delt3 == 0 && is_OnSegment(b1.p1, b2.p1, b2.p2))
                return true;
            else if (delt4 == 0 && is_OnSegment(b1.p2, b2.p1, b2.p2))
                return true;
            return false;
        }
        public static double my_min(double a, double b)
        {
            return a < b ? a : b;
        }
        public static double my_max(double a, double b)
        {
            return a > b ? a : b;
        }
        public static bool is_OnSegment(my_point p, my_point p1, my_point p2)
        {
            if ((my_min(p1.x, p2.x) <= p.x && p.x <= my_max(p1.x, p2.x)) && (my_min(p1.y, p2.y) <= p.y && p.y <= my_max(p1.y, p2.y)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
