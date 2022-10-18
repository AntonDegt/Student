using System.Collections;

namespace ConsoleСSApp
{
    class GroupEnumerator : IEnumerator
    {
        private Student[] ar;

        public GroupEnumerator(Student[] array)
        {
            ar = array;
        }

        public object Current
        {
            get;
            private set;
        }

        private int index = 0;

        public bool MoveNext()
        {
            if (index >= ar.Length) return false;

            Current = ar[index];
            index++;
            return true;
        }

        public void Reset()
        {
            index = 0;
        }
    }
}
