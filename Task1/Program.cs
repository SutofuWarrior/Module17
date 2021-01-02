using System;

namespace SkillFactory.Task1
{
    class Program
    {
        static void Main()
        {
            var exceptions = new Exception[5]
            {
                new DoNotDoThisException(),
                new NullReferenceException(),
                new OutOfMemoryException(),
                new UriFormatException(),
                new AggregateException()
            };

            for (int i = 0; i < exceptions.Length; i++)
                try
                {
                    throw exceptions[i];
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception {e.GetType()} catched on step {i}:{Environment.NewLine}{e.Message}");
                }
                finally
                {
                    Console.WriteLine($"Exception successfully handled. Proceeding to the next step.{Environment.NewLine}");
                }

            Console.ReadKey();
        }
    }

    class DoNotDoThisException : Exception
    {
    }
}
