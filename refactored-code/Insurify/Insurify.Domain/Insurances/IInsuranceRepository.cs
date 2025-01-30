namespace Insurify.Domain.Insurances;

public interface IInsuranceRepository
{
    Task<Insurance> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    void Add(Insurance insurance);
}
