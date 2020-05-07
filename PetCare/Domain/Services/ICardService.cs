﻿using PetCare.Domain.Comunication;
using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Services
{
    public interface ICardService
    {
        Task<IEnumerable<Card>> ListAsync();
        Task<CardResponse> SaveAsync(Card Card);
        Task<CardResponse> UpdateAsync(int id, Card Card);
        Task<CardResponse> DeleteAsync(int id);
    }
}