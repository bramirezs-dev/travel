using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Infraestructure.Persistence.Contexts;

namespace Travel.Unit.Context
{
    public class ContextMemoria
    {
        public TravelDbContext GetContexto() {

            var options = new DbContextOptionsBuilder<TravelDbContext>()
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .UseInMemoryDatabase(databaseName: "Test").Options;

            var context = new TravelDbContext(options);
            SeedData.SeedDataContext(context);
            return context;
        }
    }
}
