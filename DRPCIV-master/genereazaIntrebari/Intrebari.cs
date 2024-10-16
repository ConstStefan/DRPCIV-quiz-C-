/**************************************************************************
 *                                                                        *
 *  File:        Intrebari.cs                                             *
 *  Copyright:   (c) 2023, grupa 1310A, echipa 17                         *    
 *  Description: This file contains the implementation of questions       *
 *               generator                                                *
 *                                                                        *
 *                                                                        *
 **************************************************************************/


//using DRPCIV;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntrebareNmSpc;

namespace GenereazaIntrebari
{

    abstract class Iterator : IEnumerator
    {
        object IEnumerator.Current => Current();

        // Returns the current element
        public abstract object Current();

        // Move forward to next element
        public abstract bool MoveNext();

        // Rewinds the Iterator to the first element
        public abstract void Reset();
    }

    public abstract class IteratorAggregate : IEnumerable
    {
        // Returns an Iterator or another IteratorAggregate for the implementing
        // object.
        public abstract IEnumerator GetEnumerator();
    }

    // Concrete Iterators implement various traversal algorithms. These classes
    // store the current traversal position at all times.
    class IntrebariIterator : Iterator
    {
        private IntrebariCollection _collection;

        // Stores the current traversal position. An iterator may have a lot of
        // other fields for storing iteration state, especially when it is
        // supposed to work with a particular kind of collection.
        private int _position = -1;

        public IntrebariIterator(IntrebariCollection collection)
        {
            this._collection = collection;
        }

        public override object Current()
        {
            throw new NotImplementedException();
        }

        public override bool MoveNext()
        {
            int updatedPosition = this._position + 1;

            if (updatedPosition >= 0 && updatedPosition < this._collection.getItems().Count)
            {
                this._position = updatedPosition;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void Reset()
        {
            this._position = 0;
        }
    }

        // Concrete Collections provide one or several methods for retrieving fresh
        // iterator instances, compatible with the collection class.
    public class IntrebariCollection : IteratorAggregate
    {
        Queue<Intrebare> _queue = new Queue<Intrebare>();

        public Queue<Intrebare> getItems()
        {
            return _queue;
        }

        public void EnqueueItem(Intrebare item)
        {
            this._queue.Enqueue(item);
        }

        public override IEnumerator GetEnumerator()
        {
            return new IntrebariIterator(this);
        }
    }

    public class Intrebari
    {
        public static IntrebariCollection GenereazaIntrebarile(Random random, int nrIntrebariInitiale, int intrebariLength, List<Intrebare> intrebari)
        {
            // The client code may or may not know about the Concrete Iterator
            // or Collection classes, depending on the level of indirection you
            // want to keep in your program.
            var collection = new IntrebariCollection();
            random = new Random();
            int cnt = 1;
            HashSet<int> indexuriUnice = new HashSet<int>();
            while (indexuriUnice.Count < nrIntrebariInitiale)
            {
                int nrRandom = random.Next(0, intrebariLength);
                indexuriUnice.Add(nrRandom);
            }
            foreach (int index in indexuriUnice)
            {
                intrebari[index].intrebare = cnt++ + ". " + intrebari[index].intrebare;
                collection.EnqueueItem(intrebari[index]);
            }

            /*collection.AddItem("First");
            collection.AddItem("Second");
            collection.AddItem("Third");*/
            return collection;
        }
    }
}

