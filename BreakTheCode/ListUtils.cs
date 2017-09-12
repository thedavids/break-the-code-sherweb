using System;
using System.Collections;
using System.Linq;

namespace BreakTheCode
{
    public static class ListUtils
    {
        public static void ReverseInPlace(IList values)
        {
            if (values == null) throw new ArgumentNullException(nameof(values));

            var count = values.Count;
            for (int i = 0, j = count - 1; i != count / 2; ++i, j--)
        {
                var item = values[i];
                values[i] = values[j];
                values[j] = item;
            }
        }

        public static void EmptyAndDispose(IList values)
        {
            if (values == null) throw new ArgumentNullException(nameof(values));

            DisposeAll(values);
            values.Clear();
        }

        public static void DisposeAll(IEnumerable values)
        {
            if (values == null) throw new ArgumentNullException(nameof(values));

            foreach (var disposable in values.OfType<IDisposable>())
            {
                disposable.Dispose();
            }
        }
    }
}
