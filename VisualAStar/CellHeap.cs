using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualAStar
{
    /* Min Heap Implementation because C# does not natively have one */
    class CellHeap
    {
        public List<Cell> heap { get; set; }

        public CellHeap()
        {
            heap = new List<Cell>();
        }

        public void Insert(Cell c)
        {
            heap.Add(c);

            int i = heap.Count - 1;

            while (i > 0)
            {
                // Get Parent
                int j = ((i + 1) / 2) - 1;
                Cell parent = heap[j];
                if (parent.f < c.f)
                    break;

                Cell temp   = heap[i];
                heap[i]     = heap[j];
                heap[j]     = temp;

                i = j;
            }
        }

        public Cell ExtractMin()
        {
            if (heap.Count < 0)
                return null;

            Cell min = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            MinHeapify(0);

            return min;
        }

        public Cell Peek()
        {
            if (heap.Count < 1)
                return null;

            return heap[0];
        }

        private void MinHeapify(int i)
        {
            int low;
            int left    = 2 * (i + 1) - 1;
            int right   = 2 * (i + 1);

            if ((left < heap.Count) && (heap[left].f < heap[i].f))
                low = left;
            else
                low = i;

            if ((right < heap.Count) && (heap[right].f < heap[low].f))
                low = right;

            if (low != i)
            {
                Cell temp   = heap[i];
                heap[i]     = heap[low];
                heap[low]   = temp;

                MinHeapify(low);
            }
        }
    }
}
