// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System;
using IdentityServer4.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Spekkie.Constants;

namespace Spekkie
{
    public class Config
    {
        public Config(ILoggerFactory loggerFactory)
        {
            ILogger<Config> logger = loggerFactory.CreateLogger<Config>();

            logger.LogDebug($"Retrieving {EnvNames.IdsPath}");
            string idsPath = Environment.GetEnvironmentVariable(EnvNames.IdsPath)
                             ?? throw new Exception($"Environment variable {EnvNames.IdsPath} not set");

            logger.LogDebug($"Retrieving {EnvNames.ClientsPath}");
            string clientsPath = Environment.GetEnvironmentVariable(EnvNames.ClientsPath)
                                 ?? throw new Exception($"Environment variable {EnvNames.ClientsPath} not set");

            logger.LogDebug($"Retrieving {EnvNames.ApisPath}");
            string apisPath = Environment.GetEnvironmentVariable(EnvNames.ApisPath)
                              ?? throw new Exception($"Environment variable {EnvNames.ApisPath} not set");

            logger.LogInformation($"Retrieving data from {idsPath}");
            string idsData = File.ReadAllText(idsPath);
            logger.LogTrace($"Found data {idsPath}: {idsData}");
            Ids = JsonConvert.DeserializeObject<IdentityResource[]>(idsData);
            logger.LogInformation($"Found {Ids.Count()} clients in {idsPath}");

            logger.LogInformation($"Retrieving data from {clientsPath}");
            string clientData = File.ReadAllText(clientsPath);

            logger.LogTrace($"Found data {clientData}: {clientData}");
            Clients = JsonConvert.DeserializeObject<Client[]>(clientData);
            logger.LogInformation($"Found {Clients.Count()} clients in {clientsPath}");

            logger.LogInformation($"Retrieving data from {apisPath}");
            string apisData = File.ReadAllText(apisPath);

            logger.LogTrace($"Found data {apisData}: {apisData}");
            Apis = JsonConvert.DeserializeObject<ApiResource[]>(apisData);
            logger.LogInformation($"Found {Apis.Count()} clients in {apisPath}");
        }

        public IEnumerable<IdentityResource> Ids { get; }
        public IEnumerable<ApiResource> Apis { get; }
        public IEnumerable<Client> Clients { get; }
    }
}