global using MediatR;

global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.SignalR;
global using Microsoft.EntityFrameworkCore;

global using SparkplugNet;
global using SparkplugNet.Core;
global using SparkplugNet.Core.Application;
global using SparkplugNet.Custom;
global using VersionB = SparkplugNet.VersionB;
global using SparkplugNet.VersionB.Data;

global using Serilog;

global using Application;
global using Application.Commands.Nodes;
global using Application.Commands.Devices;
global using Application.Commands.Tags;
global using Application.Queries;
global using Application.Wrappers;

global using Infrastructure.Persistence;

global using Infrastructure.InfluxDb;

global using WebApi.Hubs;