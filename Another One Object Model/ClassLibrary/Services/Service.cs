using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Services
{
    public static class Service
    {
        public static void AddResize<T>(ref T[] arr)
        {
            T[] newArr = new T[arr.Length + 1];

            for (int i = 0; i < arr.Length; i++)
            {
                newArr[i] = arr[i];
            }

            arr = newArr;
        }

        public static void RemoveResize<T>(ref T[] arr, int index)
        {
            T[] newArr = new T[arr.Length - 1];

            for (int i = 0; i < index; i++)
            {
                newArr[i] = arr[i];
            }

            for (int i = index; i < newArr.Length; i++)
            {
                newArr[i] = arr[i];
            }

            arr = newArr;
        }
    }
}
