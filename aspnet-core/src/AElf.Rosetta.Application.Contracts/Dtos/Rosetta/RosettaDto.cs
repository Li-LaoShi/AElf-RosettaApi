using System.ComponentModel.DataAnnotations;

namespace AElf.Rosetta.Dtos.Rosetta;

public class RosettaDto
{
}
public class BlockIdentifierDto
{
    [Required]
    public long index { get; set; }
    [Required]
    public string hash { get; set; }
}
public class AmountDto
{
    [Required]
    public string value { get; set; }
    [Required]
    public CurrencyDto currency { get; set; }
    public object metadata { get; set; }
}