using System;
using System.Collections;
using System.Collections.Generic;

namespace UnityEngine.Rendering
{
    class DynamicArray<T> where T: new()
    //: IEnumerable<T>
    {
        T[] m_Array = null;

        public int size { get; private set; }

        public DynamicArray()
        {
            m_Array = new T[32];
            size = 32;
        }

        public DynamicArray(int size)
        {
            m_Array = new T[size];
            this.size = size;
        }

        public void Clear()
        {
            size = 0;
        }

        public int Add(in T value)
        {
            int index = size;

            // Grow array if needed;
            if (index >= m_Array.Length)
            {
                var newArray = new T[m_Array.Length * 2];
                Array.Copy(m_Array, newArray, m_Array.Length);
                m_Array = newArray;
            }

            m_Array[index] = value;
            size++;
            return index;
        }

        //IEnumerator<T> IEnumerable<T>.GetEnumerator()
        //{
        //    return (m_Array as IEnumerable<T>).GetEnumerator();
        //}

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return m_Array.GetEnumerator();
        //}


        public ref T this[int index]
        {
            get
            {
#if DEVELOPMENT_BUILD || UNITY_EDITOR
                if (index >= size)
                    throw new IndexOutOfRangeException();
#endif
                return ref m_Array[index];
            }
        }
    }

}
