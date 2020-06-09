using System.Collections.Generic;
using System.Linq;
using ImportExportTool.DAL;
using ImportExportTool.Models;
using Microsoft.EntityFrameworkCore;

namespace ImportExportTool.Logic
{
    public class DatabaseDataExporter
    {
        public IEnumerable<Oefening> GetAllOefeningenWithPrestaties()
        {
            var context = new FitContext();
            var query = context.Oefeningen
                .Include(oefening => oefening.Prestaties);

            return query.ToList();
        }
    }
}