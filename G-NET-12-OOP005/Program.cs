using System.Runtime.Intrinsics.X86;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

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




        #endregion




         }
    }
}
