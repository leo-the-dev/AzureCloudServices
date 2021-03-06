﻿using System.Threading.Tasks;
using AzureCloudServices.Bll.Services.AzureServiceBus;
using AzureCloudServices.Bll.Services.Logging;
using AzureCloudServices.Bll.Utils;
using AzureCloudServices.WebApi.Controllers.AzureServiceBus.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AzureCloudServices.WebApi.Controllers.AzureServiceBus
{
    [ApiController]
    [Route("api/v1/servicebus")]
    public class AzureServiceBusController : ControllerBase
    {
        private readonly IAzureServiceBusService _azureServiceBusService;
        private readonly ILogger _logger;
        public AzureServiceBusController(IAzureServiceBusService azureServiceBusService, ILogger logger)
        {
            _azureServiceBusService = azureServiceBusService;
            _logger = logger;
        }
        
        [HttpPost]
        public async Task<IActionResult> Send(ServiceBusEntryViewModel entry)
        {
            await _azureServiceBusService.SendMessage(entry.GetJson());
            return Ok($"Message with Id: {entry.Id} has been delivered");
        }
    }
}