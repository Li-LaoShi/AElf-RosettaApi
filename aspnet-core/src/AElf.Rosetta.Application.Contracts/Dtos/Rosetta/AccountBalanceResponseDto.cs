using System;
using System.ComponentModel.DataAnnotations;
using AElf.Rosetta.Dtos.Rosetta;

namespace AElf.Rosetta.Application;

public class AccountBalanceResponseDto
{
    [Required]
    public BlockIdentifierDto block_identifier { get; set; }
    [Required]
    public AmountDto[] balances { get; set; }
    public object metadata { get; set; }
}
