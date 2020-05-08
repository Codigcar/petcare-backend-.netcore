using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Comunication
{
    public class CardResponse : BaseResponse
    {
        public Card Card { get; private set; }

        public CardResponse(bool success, string message, Card card) : base(success, message)
        {
            Card = card;
        }

        public CardResponse(Card card) : this(true, string.Empty, card) { }

        public CardResponse(string message) : this(false, message, null) { }

    }
}
