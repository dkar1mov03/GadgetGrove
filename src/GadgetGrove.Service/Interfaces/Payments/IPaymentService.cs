using GadgetGrove.Domain.Configurations;
using GadgetGrove.Domain.Enums.PaymentStatuses;
using GadgetGrove.Service.DTOs.Payments;

namespace GadgetGrove.Service.Interfaces.Payments;

public interface IPaymentService
{
    Task<bool> RemoveAsync(long id);
    Task<PaymentForResultDto> RetrieveByIdAsync(long id);
    Task<PaymentForResultDto> AddAsync(PaymentForCreationDto dto);
    Task<PaymentForResultDto> ModifyAsync(long id, PaymentForUpdateDto dto);
    Task<PaymentForResultDto> ChangeStatusAsync(long id, PaymentStatus status);
    Task<IEnumerable<PaymentForResultDto>> RetrieveAllAsync(PaginationParams @params);
}
