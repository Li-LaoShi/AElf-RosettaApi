using System.Threading.Tasks;
using AElf.Rosetta.Dtos.Rosetta;
using Volo.Abp.Application.Services;

namespace AElf.Rosetta.Application.Contract
{
    public interface IRosettaAppService:IApplicationService
    {
        Task<AccountBalanceResponseDto> Balance(AccountBalanceRequestInput input);
    }
}

