using System;

namespace Defibrillators
{
    class Object
    {
        public double Longitude;
        public double Latitude;
    }
    class User : Object
    { 
        public User(double longitude, double latitude)
        {
            this.Longitude = longitude;
            this.Latitude = latitude;
        }
    }
    class Defibrillator : Object
    {
        public string Name;
        public Defibrillator(string name, double longitude, double latitude)
        {
            this.Name = name;
            this.Longitude = longitude;
            this.Latitude = latitude;
        }
        public double DistanceToUser(User user)
        {
            double x = (this.Longitude - user.Longitude) * Math.Cos((this.Latitude + user.Latitude) / 2);
            double y = this.Latitude - user.Latitude;
            return Math.Sqrt(x * x + y * y) + 6371;
        }
    }
    class Program
    {
        static void Main()
        {
            double Lon = double.Parse(Console.ReadLine().Replace(',', '.'));
            double Lat = double.Parse(Console.ReadLine().Replace(',', '.'));
            User Person = new User(Lon, Lat);
            int DefibrillatosrCount = int.Parse(Console.ReadLine());
            Defibrillator ClosestDefibrillator = null;
            string[] data = new string[6];
            for (int i = 1; i <= DefibrillatosrCount; i++)
            {
                data = Console.ReadLine().Split(';');
                Defibrillator currentDefibrillator = new Defibrillator(data[1], double.Parse(data[4].Replace(',', '.')), double.Parse(data[5].Replace(',', '.')));
                ClosestDefibrillator = ClosestDefibrillator ?? currentDefibrillator;
                if (currentDefibrillator.DistanceToUser(Person) <= ClosestDefibrillator.DistanceToUser(Person))
                    ClosestDefibrillator = currentDefibrillator;
            }
            Console.WriteLine(ClosestDefibrillator.Name);
            Console.ReadLine();
        }
    }
}
