﻿using PaymentsAPI.Domain.DTOs;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PaymentsAPI.Domain;

public class Contract
{
    public Contract() {
            Id = Guid.NewGuid();
            CreatedOn = DateTime.Now;
            ExpiredOn = DateTime.Now.AddDays(7);
    }
    public Guid Id { get; set; }

    public Guid UserId { get; set; }
    
    public ContractStatus Status { get; set; }

    public Guid RateId { get; set; }
    public decimal Amount { get; set; }

    public DateTime CreatedOn { get; set; }
    public DateTime ExpiredOn { get; set; }

    public ContractDTO toDTO()
    {
        return new ContractDTO
        {
            Id = this.Id,
            UserId = this.UserId,
            Status = this.Status,
            RateId = this.RateId,
            Amount = this.Amount,
            CreatedOn = this.CreatedOn,
            ExpiredOn = this.ExpiredOn,
        };
    }
}
