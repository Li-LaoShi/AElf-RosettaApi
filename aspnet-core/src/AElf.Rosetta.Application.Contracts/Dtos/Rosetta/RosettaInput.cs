using System;
using System.ComponentModel.DataAnnotations;

namespace AElf.Rosetta.Dtos.Rosetta;

public class RosettaInput
{
    
}
/// <summary>
/// The network_identifier specifies which network a particular object is associated with.
/// </summary>
public class NetworkIdentifierDto
{
    //[Required]
    public string blockchain { get; set; }
    /// <summary>
    /// If a blockchain has a specific chain-id or network identifier, it should go in this field. It is up to the client
    /// to determine which network-specific identifier is mainnet or testnet.
    /// </summary>
    //[Required]
    public string network { get; set; }
    /// <summary>
    /// In blockchains with sharded state, the SubNetworkIdentifier is required to query some object on a specific shard.
    /// This identifier is optional for all non-sharded blockchains.
    /// </summary>
    public SubNetworkIdentifierDto sub_network_identifier { get; set; }
    
}

public class SubNetworkIdentifierDto
{
    //[Required]
    public string network { get; set; }
    public object metadata { get; set; }
}
public class AccountIdentifierDto
{
    [Required]
    public string address { get; set; }
    public SubAccountIdentifierDto sub_account { get; set; }
    public object metadata { get; set; }
}

public class SubAccountIdentifierDto
{
    [Required]
    public string address { get; set; }
    public object metadata { get; set; }
}
public class PartialBlockIdentifierDto
{
    public int index { get; set; }
    public string hash { get; set; }
}
public class CurrencyDto
{
    //[Required]
    public string symbol { get; set; }
    //[Required]
    public int decimals { get; set; }
    public object metadata { get; set; }
}

