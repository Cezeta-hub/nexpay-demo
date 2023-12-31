﻿using CZ.Common.Entities;
using CZ.Common.Extensions;
using FXRatesAPI.Domain.DTOs;

namespace PaymentsAPI.Domain.DTOs;

public class ContractDTO: EffectivenessDTO
{
    public Guid Id { get; set; }
    public Guid CreatedById { get; set; }
    public AzureUser? CreatedBy { get; set; }
    public Guid? ApprovedById { get; set; }
    public AzureUser? ApprovedBy { get; set; }

    public ContractStatus Status { get; set; }
    public string StatusName { get => (new ContractStatus()).GetDescription(Status); }

    public Guid RateId { get; set; }
    public RateDTO? Rate { get; set; }
    public decimal Amount { get; set; }
}
