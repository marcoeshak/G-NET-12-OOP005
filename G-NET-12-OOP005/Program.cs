using System.ComponentModel;
using System.Runtime.Intrinsics.X86;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace G_NET_12_OOP005
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Part 01

            #region Q 01

            /*
             * An interface in C# defines a contract that a class must follow. It specifies what a class can do, not how it does it. Any class that implements the interface must provide the implementation for all its members.

             * We use interfaces instead of depending on concrete classes to avoid tight coupling and to make the code depend on abstraction rather than a specific implementation.

             * Benefits of using interfaces:

             * Loose coupling between classes.

             * Flexibility and easy extension by allowing multiple implementations.

             * Easier testing, especially when using mock implementations in unit tests.
             *
             */

            #endregion

            #region Q 02
            // A)==
            /*
            *The problem is that both IEnglishSpeaker and IArabicSpeaker have a method called Greet().
            *This creates a method name conflict.
            *Currently, the class Translator implements one method only:
            *public void Greet()
                 {
            *      Console.WriteLine("Hello / Ahlan");
            *     }
            *So the same method is used for both interfaces, and it prints "Hello / Ahlan" instead of having different behavior for each language.
            */

            //B )

            // We fix this by using Explicit Interface Implementation so each interface has its own implementation.


            // C)

            //   No, you cannot call translator.Greet() directly because the methods are implemented explicitly for the interfaces, not for the class itself.

            // You must call them through the interface reference.

            #endregion

            #region  Q 03

            /*
             1) Shallow Copy

             A shallow copy creates a new object, but it copies the references of reference - type fields instead of creating new objects.

            This means both objects share the same referenced objects in memory.

           
           2) Deep Copy

          A deep copy creates a completely independent copy of the object and all the objects it references.

          This means a new object and new copies of all referenced objects are created.

           When to use each one

            Use Shallow Copy when:

             The object contains only value types, or

             Sharing the referenced objects does not cause problems.
 
            Use Deep Copy when:

           The object contains reference - type fields, and

           You want a completely independent copy that does not affect the original object.

           Risk of using Shallow Copy with reference-type fields

           The main risk is that both objects will reference the same internal objects.

           If one object modifies the referenced object, the change will also affect the other object, which may lead to unexpected behavior or bugs.

            */

            #endregion

            #region Q 04

            /*
             
            Output
            Dev - Testing
            QA - Testing

            Explanation

           The method MemberwiseClone() creates a shallow copy of the object.

           That means:

           Value - type fields are copied normally.

           Reference - type fields copy the reference only, not the actual object
            
             */

            #endregion

            #endregion
            

            #region Part 02

            /*

        //  Interface IPrintable 
         public interface IPrintable
         {
            void Print();
         }


        // Interface IBookable 
        public interface IBookable
        {
            bool Book();
            bool Cancel();
        }


        //  Abstract Clas: Ticket 
        public abstract class Ticket : IPrintable, IBookable, ICloneable
        {
            private static int counter = 1;

            public int Id { get; set; }
            public string MovieName { get; set; }
            public double Price { get; set; }
            public bool IsBooked { get; set; }

            public Ticket(string movie, double price)
            {
                Id = counter++;
                MovieName = movie;
                Price = price;
                IsBooked = false;
            }

            public double AfterTax()
            {
                return Price * 1.14;
            }

            public bool Book()
            {
                if (IsBooked)
                    return false;

                IsBooked = true;
                return true;
            }

            public bool Cancel()
            {
                if (!IsBooked)
                    return false;

                IsBooked = false;
                return true;
            }

            public abstract void Print();

            public abstract object Clone();
        }


        // Class StandardTicket
        public class StandardTicket : Ticket
        {
            public string Seat { get; set; }

            public StandardTicket(string movie, double price, string seat)
                : base(movie, price)
            {
                Seat = seat;
            }

            public override void Print()
            {
                Console.WriteLine($"[Ticket #{Id}] {MovieName} | Standard | Seat: {Seat} | Price: {Price} | After Tax: {AfterTax()} | Booked: {(IsBooked ? "Yes" : "No")}");
            }

            public override object Clone()
            {
                return new StandardTicket(MovieName, Price, Seat);
            }
        }


        //  Class VIPTicket
        public class VIPTicket : Ticket
        {
            public bool Lounge { get; set; }
            public double Fee { get; set; }

            public VIPTicket(string movie, double price, bool lounge, double fee)
                : base(movie, price)
            {
                Lounge = lounge;
                Fee = fee;
            }

            public override void Print()
            {
                Console.WriteLine($"[Ticket #{Id}] {MovieName} | VIP | Lounge: {(Lounge ? "Yes" : "No")} | Fee: {Fee} | Price: {Price} | After Tax: {AfterTax()} | Booked: {(IsBooked ? "Yes" : "No")}");
            }

            public override object Clone()
            {
                return new VIPTicket(MovieName, Price, Lounge, Fee);
            }
        }


        //  Class IMAXTicket 
        public class IMAXTicket : Ticket
        {
            public bool Is3D { get; set; }

            public IMAXTicket(string movie, double price, bool is3D)
                : base(movie, price)
            {
                Is3D = is3D;
            }

            public override void Print()
            {
                Console.WriteLine($"[Ticket #{Id}] {MovieName} | IMAX | 3D: {(Is3D ? "Yes" : "No")} | Price: {Price} | After Tax: {AfterTax()} | Booked: {(IsBooked ? "Yes" : "No")}");
            }

            public override object Clone()
            {
                return new IMAXTicket(MovieName, Price, Is3D);
            }
        }


        //  Class Cinema 
        public class Cinema
        {
            public List<Ticket> Tickets = new List<Ticket>();

            public void Open()
            {
                Console.WriteLine("=== Cinema Opened ===");
            }

            public void Close()
            {
                Console.WriteLine("=== Cinema Closed ===");
            }

            public void AddTicket(Ticket t)
            {
                Tickets.Add(t);
            }

            public void PrintTickets()
            {
                Console.WriteLine("\n--- All Tickets ---");

                foreach (var t in Tickets)
                    t.Print();
            }
        }


        //  Class BookingHelper 
        public static class BookingHelper
        {
            public static void PrintAll(IPrintable[] items)
            {
                foreach (var item in items)
                    item.Print();
            }
        }


        //  Class: Program 
        class Program
        {
            static void Main()
            {
                Cinema cinema = new Cinema();
                cinema.Open();

                StandardTicket t1 = new StandardTicket("Inception", 80, "A5");
                VIPTicket t2 = new VIPTicket("Avengers", 200, true, 50);
                IMAXTicket t3 = new IMAXTicket("Dune", 130, true);

                t1.Book();
                t2.Book();
                t3.Book();

                cinema.AddTicket(t1);
                cinema.AddTicket(t2);
                cinema.AddTicket(t3);

                cinema.PrintTickets();

                Console.WriteLine("\n--- Clone Test ---");

                VIPTicket clone = (VIPTicket)t2.Clone();
                clone.MovieName = "Interstellar";

                Console.Write("Original : ");
                t2.Print();

                Console.Write("Clone    : ");
                clone.Print();

                Console.WriteLine("\n--- After Cancellation ---");

                t1.Cancel();
                t1.Print();

                Console.WriteLine("\n--- BookingHelper.PrintAll ---");

                IPrintable[] arr = { t1, t2, t3 };
                BookingHelper.PrintAll(arr);

                cinema.Close();
            }
        }

        */
            #endregion


        }
    }
}
