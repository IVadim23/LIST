using Microsoft.VisualBasic;
using System;
using System.Buffers;

namespace LIST
{
    public class CustomArrayList
    {
        private object[] arr;

        private int count;
        public int Count
        {
            get
            {
                return count;
            }
        }

        private static readonly int INITIAL_CAPACITY = 4;

        public CustomArrayList()
        {
            arr = new object[INITIAL_CAPACITY];
            count = 0;
        }
        public void Add(object item)
        {
            if (this.Count == this.arr.Length)
            {
                this.Resize();
            }
            this.arr[count++] = item;
        }

        public void Resize()
        {
            object[] NewArr = new object[this.arr.Length * 2];
            for (int i = 0; i < this.arr.Length; i++)
            {
                NewArr[i] = this.arr[i];
            }
            this.arr = NewArr;
        }
        public void Insert(int index, object item)
        {
            if (index > this.Count)
            {
                throw new IndexOutOfRangeException();
            }
            if (this.Count == this.arr.Length)
            {
                Resize();
            }
            for (int i = 0; i > this.arr.Length; i--)
            {
                this.arr[i] = this.arr[i - 1];
            }
            this.arr[index] = item;
            this.count++;

        }
        public int IndexOf(object item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.arr[i] == item)
                {
                    return i;
                }
            }
            return -1;

        }
        public void Clear()
        {
            this.arr = null;
            this.arr = new object[INITIAL_CAPACITY * 0];
            this.count = 0;
        }
        public bool Contains(object item)
        {
            IndexOf(item);
            if (IndexOf(item) != -1)
            {
                return true;
            }
            return false;
        }
        public object this[int index]
        {
            get
            {
                return this.arr[index];
            }
            set
            {
                this.arr[index] = value;
            }
        }
        public object Remove(int index)
        {
            if (index > this.Count)
            {
                throw new ArgumentOutOfRangeException("index");
            }
            object el = this.arr[index];
            this.arr[index] = default(object);
            this.Shift();
            this.count--;

            if (this.Count < this.arr.Length / 4)
            {
                Shrink();
            }
            return el;
        }
        public void Shift()
        {
            for (int i = 0; i < this.arr.Length; i++)
            {
                this.arr[i] = this.arr[i + 1];
            }

        }

        public void Shrink()
        {
            object[] NewArr2 = new object[this.arr.Length / 2];
            for (int i = 0; i < this.Count; i++)
            {
                NewArr2[i] = this.arr[i];
            }
            this.arr = NewArr2;
        }
        public int Remove(object item)
        {
            for (int i = 0; i < this.arr.Length; i++)
            {
                this.count--;
            }
            return -1;
        }

    }
}
