using System;

namespace Treinamento.Angular.Api.Models
{
    public class Account
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public decimal Value { get; set; }

        public DateTime Date { get; set; }
    }
}