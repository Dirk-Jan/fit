using System;
using System.Collections.Generic;
using ImportExportTool.Commands;
using ImportExportTool.Models;
using Minor.Miffy.MicroServices.Commands;

namespace ImportExportTool.Logic
{
    public class DataImporter
    {
        private ICommandPublisher _commandPublisher;

        public DataImporter(ICommandPublisher commandPublisher)
        {
            _commandPublisher = commandPublisher;
        }
        
        public async void ImportOefeningenIntoSystem(IList<Oefening> oefeningen, Guid klantId)
        {
            foreach (var oefening in oefeningen)
            {
                var returnCommand = await _commandPublisher.PublishAsync<MaakOefeningAanCommand>(
                    new MaakOefeningAanCommand
                    {
                        Oefening = oefening
                    });

                foreach (var prestatie in oefening.Prestaties)
                {
                    prestatie.OefeningId = returnCommand.Oefening.Id;
                    // prestatie.KlantId = klantId;
                    await _commandPublisher.PublishAsync<RegistreerPrestatieCommand>(
                        new RegistreerPrestatieCommand
                        {
                            Prestatie = prestatie
                        });
                }
            }
        }
    }
}