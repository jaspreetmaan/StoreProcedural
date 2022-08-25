using Microsoft.EntityFrameworkCore;

namespace StoreProcedural.Data
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

    }
}
