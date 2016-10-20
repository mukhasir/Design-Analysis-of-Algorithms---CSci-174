using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GridWalk
{
    class Location
    {
        public int x { get; set; }
        public int y { get; set; }
        public bool equals(Object ins) {
			Location arg = (Location) ins;
			if (arg == null) return false;
			return (x == arg.x && y == arg.y);
		}
		
		public int hashCode() {
			return this.x + this.y;
		}
    }
    class Program
    {
        public static List<Location> reachables = new List<Location>();
        // Mark location as visited and add adjacent locations if they are newly found and accessible/reachable.
        static void Main(string[] args)
        {
            Dictionary<Location, bool> visited = new Dictionary<Location, bool>();
            Location start = new Location();
            start.x = 0;
            start.y = 0;
            reachables.Add(start);
            int index = 0;
            while (true)
            {
                if (index >= reachables.Count())
                    break;
                visit(reachables.ElementAt(index), visited);
                if (index >= 9)
                    break;
                index++;
            }
            Console.WriteLine(reachables.Count());
        }
        public static bool Present(Dictionary<Location,bool> visited, Location loc)
        {
            bool value = false;
            foreach(KeyValuePair<Location,bool> vd in visited)
            {
                if(loc.x == vd.Key.x && loc.y == vd.Key.y)
                {
                    value = true;
                }
            }
            return value;
        }
        public static void visit(Location loc, Dictionary<Location,bool> visited)
        {
            if (visited.ContainsKey(loc))
            {
                visited.Remove(loc);
                visited.Add(loc, true);
            }
            else
            {
                visited.Add(loc, true);
            }
            Location left = new Location();
            left.x = Convert.ToInt32(loc.x - 1);
            left.y = loc.y;
            Location right = new Location();
            right.x = Convert.ToInt32(loc.x + 1);
            right.y = Convert.ToInt32(loc.y);
            Location up = new Location();
            up.x = loc.x;
            up.y = loc.y + 1;
            Location down = new Location();
            down.x = loc.x;
            down.y = loc.y - 1;

            addIfNewAccessibleLocation(left, visited);
            bool item = true;
            if (visited.TryGetValue(right, out item))
                Console.WriteLine("HI");
            addIfNewAccessibleLocation(right, visited);
            addIfNewAccessibleLocation(down, visited);
            addIfNewAccessibleLocation(up, visited);
        }
        public static void addIfNewAccessibleLocation(Location loc1, Dictionary<Location,bool> visited)
        {
            if (visited.ContainsKey(loc1))
            {
                Console.WriteLine(loc1.x + ":::" + loc1.y);
            }
            if (!Present(visited, loc1) && isAccessible(loc1))
            {
                reachables.Add(loc1);
                visited.Add(loc1, false);
            }
        }

        // Condition for whether or not a 2D location is accessible.
        public static bool isAccessible(Location loc)
        {
            return (sumDigits(loc.x) + sumDigits(loc.y) <= 19);
        }

        // Method which sums the digits of a number.
        public static int sumDigits(int n)
        {
            if (n == 0) return 0;
            n = Math.Abs(n);
            return (n % 10) + sumDigits(n / 10);
        }
    }
}
