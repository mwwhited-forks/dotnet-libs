using System.Collections.Generic;
using System.Linq;

namespace Eliassen.System.Collections.Generic
{
    public static class LinkedListExtensions
    {
        public static IEnumerable<T> BeforeThis<T>(this LinkedList<T> list, T current) =>
            list.Find(current)?.Before() ?? Enumerable.Empty<T>();

        public static IEnumerable<T> Before<T>(this LinkedListNode<T> current)
        {
            LinkedListNode<T>? node = current;
            while ((node = node?.Previous) != null)
                yield return node.Value;
        }
    }
}
