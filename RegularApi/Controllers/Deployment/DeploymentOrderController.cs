using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RegularApi.Domain.Model;
using RegularApi.Domain.Views;
using RegularApi.Services;
using RegularApi.Transformers;

namespace RegularApi.Controllers.Deployment
{
    [ApiController]
    [Route("/deployment-orders")]
    public class DeploymentOrderController : AbstractController
    {
        private readonly ILogger<DeploymentOrderController> _logger;
        private readonly ITransformer<DeploymentOrderView, DeploymentOrder> _deploymentOrderTransformer;
        private readonly DeploymentService _deploymentService;

        public DeploymentOrderController(ILogger<DeploymentOrderController> logger,
                                         ITransformer<DeploymentOrderView, DeploymentOrder> deploymentOrderTransformer,
                                         DeploymentService deploymentService)
        {
            _logger = logger;
            _deploymentOrderTransformer = deploymentOrderTransformer;
            _deploymentService = deploymentService;
        }

        [HttpPost]
        public async Task<IActionResult> NewAsync(DeploymentOrderView deploymentOrderView)
        {
            _logger.LogInformation("deployment request received: {0}", deploymentOrderView.DeploymentTemplateId);

            var deploymentOrder = _deploymentOrderTransformer.Transform(deploymentOrderView);

            var result = await _deploymentService.QueueDeploymentOrderAsync(deploymentOrder);

            var action = result.Match<IActionResult>(
                right => Ok(BuildNewResourceResponseView("/deployment-orders", right.RequestId)),
                left => UnprocessableEntity(BuildErrorResponse(left)));

            return action;
    }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeploymentOrderByRequestIdAsync([FromRoute] string id)
        {
            var deploymentOrderHolder = await _deploymentService.GetDeploymentOrderByRequestIdAsync(id);

            return deploymentOrderHolder.Match<IActionResult>(
                right => Ok(_deploymentOrderTransformer.Transform(right)),
                left => NotFound());
        }
    }
}