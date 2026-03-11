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


            #endregion




        }
    }
}
