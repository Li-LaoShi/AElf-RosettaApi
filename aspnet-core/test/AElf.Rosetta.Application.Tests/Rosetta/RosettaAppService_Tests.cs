using System.Threading.Tasks;
using AElf.Rosetta.Application.Contract;
using AElf.Rosetta.Dtos.Rosetta;
using Shouldly;
using Xunit;

namespace AElf.Rosetta.Rosetta;

public class RosettaAppService_Tests : RosettaApplicationTestBase
{
    private readonly IRosettaAppService _rosettaAppService;

    public RosettaAppService_Tests()
    {
        _rosettaAppService = GetRequiredService<IRosettaAppService>();
    }
    
    [Fact]
    public async Task Test_Balance()
    {
        var result = await _rosettaAppService.Balance
        (new AccountBalanceRequestInput()
            {
                account_identifier = new AccountIdentifierDto()
                    { address = "NTScWyUinp1dN8vUrxCoMto3aNnz7qq39vktTNVQjPz4uBpgy" }
            }
        );
        result.balances[1].currency.symbol.ShouldBe("ELF");
    }
    
}