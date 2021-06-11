using System;
using System.Collections.Generic;

namespace IteratorPattern
{
    // Step1: Create the collection item

    class Elempoyee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Elempoyee(string name, int id)
        {
            Name = name;
            ID = id;
        }
    }

    // Step2: Creating Abstract Iterator
    interface AbstractIterator
    {
        Elempoyee First();
        Elempoyee Next();
        bool IsCompleted { get; }
    }

    // Step3: Creating Concrete Iterator

    class Iterator : AbstractIterator
    {
        private ConcreteCollection collection;
        private int current = 0;
        private int step = 1;

        // Constructor
        public Iterator(ConcreteCollection collection)
        {
            this.collection = collection;
        }

        // Gets first item
        public Elempoyee First()
        {
            current = 0;
            return collection.GetEmployee(current);
        }

        // Gets next item
        public Elempoyee Next()
        {
            current += step;
            if (!IsCompleted)
            {
                return collection.GetEmployee(current);
            }
            else
            {
                return null;
            }
        }

        // Check whether iteration is complete
        public bool IsCompleted
        {
            get { return current >= collection.Count; }
        }
    }

    // Step4: Creating Aggregate

    interface AbstractCollection
    {
        Iterator CreateIterator();
    }

    // Step5: Creating ConcreteAggregate 
    class ConcreteCollection : AbstractCollection
    {
        private List<Elempoyee> listEmployees = new List<Elempoyee>();
        //Create Iterator
        public Iterator CreateIterator()
        {
            return new Iterator(this);
        }
        // Gets item count
        public int Count
        {
            get { return listEmployees.Count; }
        }
        //Add items to the collection
        public void AddEmployee(Elempoyee employee)
        {
            listEmployees.Add(employee);
        }
        //Get item from collection
        public Elempoyee GetEmployee(int IndexPosition)
        {
            return listEmployees[IndexPosition];
        }

        /// <summary>
        /// 
        /// </summary>
        class Program
        {
            static void Main(string[] args)
            {
                // Build a collection
                ConcreteCollection collection = new ConcreteCollection();
                collection.AddEmployee(new Elempoyee("Anurag", 100));
                collection.AddEmployee(new Elempoyee("Pranaya", 101));
                collection.AddEmployee(new Elempoyee("Santosh", 102));
                collection.AddEmployee(new Elempoyee("Priyanka", 103));
                collection.AddEmployee(new Elempoyee("Abinash", 104));
                collection.AddEmployee(new Elempoyee("Preety", 105));

                // Create iterator
                Iterator iterator = collection.CreateIterator();
                //looping iterator      
                Console.WriteLine("Iterating over collection:");

                for (Elempoyee emp = iterator.First(); !iterator.IsCompleted; emp = iterator.Next())
                {
                    Console.WriteLine($"ID : {emp.ID} & Name : {emp.Name}");
                }
                Console.Read();
            }
        }
    }
}
