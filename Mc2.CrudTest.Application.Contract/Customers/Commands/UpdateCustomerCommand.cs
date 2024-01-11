﻿using Ardalis.Result;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Mc2.CrudTest.Application.Contract.Customers.Commands;

public class UpdateCustomerCommand : IRequest<Result>
{
    [Required]
    public Guid Id { get; init; }

    [Required]
    [MaxLength(100)]
    [DataType(DataType.Text)]
    public string Firstname { get; init; }

    [Required]
    [MaxLength(100)]
    [DataType(DataType.Text)]
    public string Lastname { get; init; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; init; }

    [Required]
    [DataType(DataType.PhoneNumber)]
    public string PhoneNumber { get; init; }

    [Required]
    [MaxLength(100)]
    [DataType(DataType.EmailAddress)]
    public string Email { get; init; }

    [Required]
    public string BankAccountNumber { get; init; }
}
