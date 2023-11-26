﻿using CZ.Common.Entities;
using CZ.Common.Utilities;
using PaymentsAPI.Domain;
using PaymentsAPI.Domain.Params;
using PaymentsAPI.Repository;

namespace PaymentsAPI.WebAPI.Services;

public class ContractsService
{
    private readonly ContractsRepository _contractsRepository;
    public ContractsService(ContractsRepository contractsRepository)
    {
        _contractsRepository = contractsRepository;
    }

    public async Task<IEnumerable<Contract>> GetAllContracts()
        => await _contractsRepository.GetAllContracts();
    
    public async Task<IEnumerable<Contract>> GetContractsByUserId(Guid userId)
        => await _contractsRepository.GetContractsByUserId(userId);
    
    public async Task<Contract> GetContractById(Guid id)
        => await _contractsRepository.GetContractById(id);
    
    public async Task<Contract> CreateContract(CreateContractParam param)
    {
        Contract newContract = new Contract(param.UserId);
        newContract.RateId = param.RateId;
        newContract.Amount = param.Amount;

        await _contractsRepository.CreateContract(newContract);
        await SendNotificationEmail(newContract);

        return newContract;
    }

    public async Task<Contract> UpdateContractStatus(UpdateContractStatusParam param)
        => await _contractsRepository.UpdateContractStatus(param.ContractId,param.NewStatus);

    // Email Utils
    private async Task SendNotificationEmail(Contract c)
    {
        EmailHelper emailHelper = new EmailHelper("julic206@gmail.com", "rltn okpg yphq aepf");
        await emailHelper.SendEmailAsync(new MailContents
        {
            Sender = "julic206@gmail.com",
            Receiver = "julic206@gmail.com",
            Subject = "A new Contract has been created",
            Body = $"User {c.UserId} placed a new Contract (id: {c.Id}) at {c.CreatedOn.ToLocalTime()}. \r\nPlease visit our page to review and update status."
        });
    } 
}