namespace ucn_user_review_backend_v3.Util;

public class Collections
{

    private Collections() {}

    /**
     * Define empty IList, used when is retrieve
     * empty elements
     */
    public static IList<T> EmptyList<T>()
    {
        return new List<T>();
    }

    /**
     * Define a empty set, used when is retrieve
     * empty elements
     */

    public static ISet<T> EmptySet<T>()
    {
        return new HashSet<T>();
    }
    
}