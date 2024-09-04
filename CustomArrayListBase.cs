namespace LIST
{
    public class CustomArrayListBase
    {
        public int IndexOf(object item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.arr[i] == item)
                {
                    return i;
                }
                return -1;
            }

        }
    }
}