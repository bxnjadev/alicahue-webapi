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
     * Define empty set, used when is retrieve
     * empty elements
     */

    public static ISet<T> EmptySet<T>()
    {
        return new HashSet<T>();
    }

    /**
     * Add element to collection if a condition is true 
     */
    
    public static void AddIf<T>(    bool condition,
        ICollection<T> collection,
        T element)
    {
        if (condition)
        {
            collection.Add(element);
        }
    }
    
}