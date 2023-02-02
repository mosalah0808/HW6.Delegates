using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6.Delegates
{
    public static class GetMaxElem
    {
        public static T GetMax<T>(this IEnumerable<T> e, Func<T, float> getParameter)
            where T : class
        {
            if (getParameter == null)
                throw new ArgumentNullException(nameof(getParameter));

            T? maxItem = default;
            float? max = float.MinValue;

            foreach (T current in e)
            {
                float value = getParameter(current);

                if (max < value)
                {
                    maxItem = current;
                    max = value;
                }
            }

            return maxItem;
        }
    }
}
