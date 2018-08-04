using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;


namespace Apollo.Data
{
    // Info : This is what let’s us self contain the class library, rather than relying on the 
    //configuration of the startup project. Used only for local DEV while creating migrations
    // A factory for creating derived <see cref="T:Microsoft.EntityFrameworkCore.DbContext" /> instances. Implement this interface to enable
    //    design-time services for context types that do not have a public default constructor.At design-time,
    //      derived<see cref="T:Microsoft.EntityFrameworkCore.DbContext" /> instances can be created in order to enable specific design-time
    //   experiences such as Migrations.Design-time services will automatically discover implementations of
    //      this interface that are in the startup assembly or the same assembly as the derived context.

    public class ApolloContextFactory : IDesignTimeDbContextFactory<ApolloContext>
    {
        public ApolloContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ApolloContext>();
            builder.UseSqlServer("data source=.\\sqlexpress;initial catalog=Apollo;Trusted_Connection=true;MultipleActiveResultSets=true;",
                optionsBuilder => optionsBuilder.
                MigrationsAssembly(typeof(ApolloContext).GetTypeInfo().Assembly.GetName().Name));
            return new ApolloContext(builder.Options);
        }
    }
}
