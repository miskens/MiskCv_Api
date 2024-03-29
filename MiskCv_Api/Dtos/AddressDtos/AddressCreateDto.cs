﻿namespace MiskCv_Api.Dtos.AddressDtos;

public record struct AddressCreateDto(
    string Street,
    string PostNr,
    string City,
    string Country,
    int? UserId
    );
