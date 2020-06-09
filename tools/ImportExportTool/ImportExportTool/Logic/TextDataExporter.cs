using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using ImportExportTool.Models;

namespace ImportExportTool.Logic
{
    public class TextDataExporter
    {
        public IEnumerable<Oefening> ReadAllOefeningenWithPrestatiesFromLines(IList<string> lines)
        {
            // var lines = GetAllLinesFromFile(filePath);
            var oefeningen = new List<Oefening>();

            Oefening readOefening = null;
            int offset = 0;
            for(;;)
            {
                readOefening = ReadOefeningWithPrestaties(lines.ToList(), ref offset);
                if (readOefening == null)
                    break;
                
                oefeningen.Add(readOefening);
            }
            return oefeningen;
        }

        private Oefening ReadOefeningWithPrestaties(IList<string> lines, ref int offset)
        {
            var naamRegex = "(N|n)aam.*:";
            var omschrijvingRegex = "(O|o)mschrijving.*:";

            var datumTijdRegex = @"\d{2}-\d{2}-\d{4}(T\d{2}:\d{2}:\d{2}|)";
            var gewichtRegex = @"(\d+|-|)";
            var repsRegex = @"[1-9]\d*";
            var opmerkingRegex = @"(\|.*|)";
            var prestatieRegex = $@"^{datumTijdRegex}\|{gewichtRegex}\|{repsRegex}{opmerkingRegex}$";


            string naam = null;
            bool naamFound = false;
            string omschrijving = null;
            bool omschrijvingFound = false;
            var prestaties = new List<Prestatie>();
            for (; offset < lines.Count; offset++)
            {
                var line = lines[offset];
                if (!naamFound)
                {
                    if (Regex.IsMatch(line, naamRegex))
                    {
                        naam = line.Split(':')[1].Trim();
                        naamFound = true;
                    }
                }
                else if (!omschrijvingFound)
                {
                    if (Regex.IsMatch(line, omschrijvingRegex))
                    {
                        omschrijving = line.Split(':')[1].Trim();
                        omschrijvingFound = true;
                    }
                }
                else
                {
                    if (Regex.IsMatch(line, naamRegex))
                    {
                        // Nieuwe oefening gevonden
                        return new Oefening
                        {
                            Naam = naam,
                            Omschrijving = omschrijving,
                            Prestaties = prestaties
                        };
                    }

                    if (Regex.IsMatch(line, prestatieRegex))
                    {
                        prestaties.Add(GetPrestatieFromPrestatieString(line));
                    }
                }
            }

            if (naamFound && omschrijvingFound)
            {
                return new Oefening
                {
                    Naam = naam,
                    Omschrijving = omschrijving,
                    Prestaties = prestaties
                };
            }
            return null;
        }

        private Prestatie GetPrestatieFromPrestatieString(string prestatieString)
        {
            var prestatieStringPieces = prestatieString.Split('|');
            var datumTijdString = prestatieStringPieces[0];
            var gewichtString = prestatieStringPieces[1];
            var repsString = prestatieStringPieces[2];
            var opmerkingString = prestatieStringPieces.Length < 4 ? null : prestatieStringPieces[3];

            DateTime dateTime;
            if (datumTijdString.Contains("T"))
            {
                dateTime = DateTime.ParseExact(datumTijdString, "dd-MM-yyyyTHH:mm:ss", CultureInfo.InvariantCulture);
            }
            else
            {
                dateTime = DateTime.ParseExact(datumTijdString, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            }

            var gewicht = string.IsNullOrEmpty(gewichtString) || !Regex.IsMatch(gewichtString, @"^\d+$") ? (double?) null : Convert.ToDouble(gewichtString);
            var reps = Convert.ToInt32(repsString);
            return new Prestatie
            {
                Datum = dateTime,
                Gewicht = gewicht,
                Herhalingen = reps,
                Opmerking = opmerkingString
            };
        }
    }
}