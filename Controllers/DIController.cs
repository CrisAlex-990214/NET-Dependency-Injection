using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DIController : ControllerBase
    {
        private readonly ITransientDependency transientDependency;
        private readonly IScopedDependency scopedDependency;
        private readonly ISingletonDependency singletonDependency;

        public DIController(ITransientDependency transientDependency,
            IScopedDependency scopedDependency, ISingletonDependency singletonDependency)
        {
            this.transientDependency = transientDependency;
            this.scopedDependency = scopedDependency;
            this.singletonDependency = singletonDependency;
        }

        [HttpGet]
        public IEnumerable<Guid> Get(IServiceProvider serviceProvider)
        {
            yield return transientDependency.Guid;
            yield return serviceProvider.GetService<ITransientDependency>().Guid;
            yield return scopedDependency.Guid;
            yield return serviceProvider.GetService<IScopedDependency>().Guid;
            yield return singletonDependency.Guid;
            yield return serviceProvider.GetService<ISingletonDependency>().Guid;
        }
    }
}