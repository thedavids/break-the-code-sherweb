using System;
using System.Collections;
using System.Linq;

namespace BreakTheCode
{
    public static class ListUtils
    {
        public static void ReverseInPlace(IList values)
        {
            AssertValuesNotNull(values);

            var count = values.Count;
            for (int i = 0, j = count - 1; i != count / 2; ++i, j--)
            {
                var temp = values[i];
                values[i] = values[j];
                values[j] = temp;
            }
        }

        public static void EmptyAndDispose(IList values)
        {
            AssertValuesNotNull(values);

            DisposeAll(values);
            values.Clear();
        }

        public static void DisposeAll(IEnumerable values)
        {
            AssertValuesNotNull(values);

            foreach (var disposable in values.OfType<IDisposable>())
            {
                disposable.Dispose();
            }
        }

        private static void AssertValuesNotNull(IEnumerable values)
        {
            if (values == null) throw new ArgumentNullException(nameof(values));
        }
    }
}
