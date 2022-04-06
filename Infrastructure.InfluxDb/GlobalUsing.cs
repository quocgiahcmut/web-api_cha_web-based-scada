global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Text;
global using System.Threading.Tasks;

global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.Options;

global using InfluxDB.Client;
global using InfluxDB.Client.Linq;
global using InfluxDB.Client.Core;
global using InfluxDB.Client.Writes;
global using InfluxDB.Client.Api.Domain;

global using Domain.Repositories;
global using Domain.Models;

global using Infrastructure.InfluxDb.Core;
global using Infrastructure.InfluxDb.Repositories;