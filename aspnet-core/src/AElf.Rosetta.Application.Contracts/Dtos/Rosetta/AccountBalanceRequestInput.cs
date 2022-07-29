using System.ComponentModel.DataAnnotations;

namespace AElf.Rosetta.Dtos.Rosetta;

/// <summary>
/// An AccountBalanceRequest is utilized to make a balance request on the /account/balance endpoint. If the
/// block_identifier is populated, a historical balance query should be performed.
/// </summary>
public class AccountBalanceRequestInput
{
    /// <summary>
    /// The network_identifier specifies which network a particular object is associated with.
    /// </summary>
    //[Required]
    public NetworkIdentifierDto network_identifier{get; set;}
    
    /// <summary>
    /// The account_identifier uniquely identifies an account within a network. All fields in the account_identifier are
    /// utilized to determine this uniqueness (including the metadata field, if populated).
    /// </summary>
    //[Required]
    public AccountIdentifierDto account_identifier { get; set; }
    
    /// <summary>
    /// When fetching data by BlockIdentifier, it may be possible to only specify the index or hash. If neither property
    /// is specified, it is assumed that the client is making a request at the current block.
    /// </summary>
    public PartialBlockIdentifierDto block_identifier { get; set; }
    
    /// <summary>
    /// In some cases, the caller may not want to retrieve all available balances for an AccountIdentifier. If the
    /// currencies field is populated, only balances for the specified currencies will be returned. If not populated,
    /// all available balances will be returned.
    /// </summary>
    public CurrencyDto[] currencies { get; set; }
}