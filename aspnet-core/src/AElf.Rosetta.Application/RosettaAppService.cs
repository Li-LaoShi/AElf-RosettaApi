using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AElf.Client.Dto;
using AElf.Client.MultiToken;
using AElf.Client.Proto;
using AElf.Client.Service;
using AElf.Rosetta.Application;
using AElf.Rosetta.Application.Contract;
using AElf.Rosetta.Dtos.Rosetta;
using AElf.Rosetta.Localization;
using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Volo.Abp.Application.Services;

namespace AElf.Rosetta;

/* Inherit your application services from this class.
 */
public class RosettaAppService : ApplicationService,IRosettaAppService
{
    public RosettaAppService()
    {
        LocalizationResource = typeof(RosettaResource);
    }

    private const string TestUrl = "https://aelf-test-node.aelf.io";
    private const string BaseUrl = "https://aelf-node.aelf.io";
    /// <summary>
    /// Account/Balance
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<AccountBalanceResponseDto> Balance(AccountBalanceRequestInput input)
    {
        if (input == null)
        {
            return new AccountBalanceResponseDto();
        }
        
        AElfClient client = new AElfClient(TestUrl);
        var isConnected = await client.IsConnectedAsync();
        if (!isConnected)
        {
            return new AccountBalanceResponseDto();
        }
        // return isConnected;
        var Account =client.GenerateKeyPairInfo();
        var tokenContractAddress = await client.GetContractAddressByNameAsync(HashHelper.ComputeFrom("AElf.ContractNames.Token"));
        var Toadress = input.account_identifier.address;
        var paramGetBalance = new GetBalanceInput
        {
            Symbol = "ELF",
            Owner = new Address{Value = AElf.Types.Address.FromBase58(Toadress).Value}
        };
        var transactionGetBalance = await client.GenerateTransactionAsync(Account.Address,tokenContractAddress.ToBase58(),"GetBalance",paramGetBalance);
        var txWithSignGetBalance = client.SignTransaction(Account.PrivateKey, transactionGetBalance);

        var transactionGetBalanceResult = await client.ExecuteTransactionAsync(new ExecuteTransactionDto
        {
            RawTransaction = txWithSignGetBalance.ToByteArray().ToHex()
        });

        var balance = GetBalanceOutput.Parser.ParseFrom(ByteArrayHelper.HexStringToByteArray(transactionGetBalanceResult));
        //Console.WriteLine(balance.Balance);
        
        
        var chainStatus = await client.GetChainStatusAsync();
        return new AccountBalanceResponseDto
        {
            block_identifier = { index = chainStatus.BestChainHeight, hash = chainStatus.BestChainHash },
            balances = new AmountDto[]
            {
                new AmountDto()
                {
                    value = balance.Balance.ToString(),
                    currency = new CurrencyDto()
                    {
                        symbol = balance.Symbol,
                        decimals = 8
                    },
                    metadata = {}
                },
            },
            metadata = {}
        };

    }
}
