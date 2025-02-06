using ucn_user_review_backend_v3.Model;

namespace ucn_user_review_backend_v3.Mapper.Types;

public class BlockMapper : IObjectMapper<Block,
BlockView>
{
    
    public BlockView Map(Block entity)
    {
        return new BlockView
        {
            BlockValue = entity.BlockValue,
            Id = entity.Id
        };
    }
    
}