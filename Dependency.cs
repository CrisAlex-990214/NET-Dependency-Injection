public class Dependency : ITransientDependency, IScopedDependency, ISingletonDependency
{
    public Guid Guid { get; } = Guid.NewGuid();
}