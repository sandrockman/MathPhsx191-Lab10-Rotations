using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        int choice = 0;
        string terminate;
        double newX, newY, newZ;
        newX = newY = newZ = 0;
        double newW = 1;
        List<Vector3D> objectList = new List<Vector3D>();
        do
        {
            Console.Clear();
            Console.WriteLine("Entering object points...");
            Console.WriteLine("Point " + (objectList.Count + 1));
            Console.Write("Enter X coord: ");
            newX = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter Y coord: ");
            newY = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter Z coord: ");
            newZ = Convert.ToDouble(Console.ReadLine());
            objectList.Add(new Vector3D(newX, newY, newZ, newW));
            Console.Write("Add another object point? ('Y' or 'N')");
            terminate = Console.ReadLine();

        } while (terminate.ToUpper()[0] == 'Y');

        choice = 0;
        terminate = null;
        List<Vector3D> rotation;
        do
        {
            Console.Clear();
            Console.WriteLine("1: Rotate around X axis.");
            Console.WriteLine("2: Rotate around Y axis.");
            Console.WriteLine("3: Rotate around Z axis.");
            Console.Write("Please enter No. for rotation: ");
            choice = Convert.ToInt32(Console.ReadLine());

            Console.Write("Please enter rotation change in degrees: ");
            double theta = Convert.ToDouble(Console.ReadLine());

            rotation = new List<Vector3D>();
            switch(choice)
            {
                case 1:
                    rotation = Vector3D.RotateAroundXAxis(objectList, theta);
                    break;
                case 2:
                    rotation = Vector3D.RotateAroundYAxis(objectList, theta);
                    break;
                case 3:
                    rotation = Vector3D.RotateAroundZAxis(objectList, theta);
                    break;
            }
            int count = 1;
            foreach (Vector3D item in rotation)
            {
                Console.WriteLine("Point " + count + ": <" + item.XValue + ", "
                    + item.YValue + ", " + item.ZValue + ">.");
                count++;
            }

            Console.Write("Commit another rotation? ('Y' or 'N')");
            terminate = Console.ReadLine();

        } while (terminate.ToUpper()[0] == 'Y');
    }
}
