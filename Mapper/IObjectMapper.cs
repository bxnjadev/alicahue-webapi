namespace ucn_user_review_backend_v3.Mapper;

public interface IObjectMapper<E,
    R>
{
    
    /**
     * Convert a type entity E to type entity R
     */
    
    R Map(E entity);

    ICollection<R> Map(ICollection<E> entities)
    {
        var group = new List<R>();
        foreach(var e in entities)
        {
            group.Add(Map(e));
        }

        return group;
    }
    
}