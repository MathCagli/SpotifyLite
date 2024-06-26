﻿namespace SpotifyLite.Domain.Models.Core.ValueObject
{
    public record Monetario
    {
        public decimal Valor { get; set; }

        public static implicit operator decimal(Monetario d) => d.Valor;
        public static implicit operator Monetario(decimal valor) => new Monetario(valor);

        public Monetario()
        {

        }

        public Monetario(decimal valor)
        {
            if (valor < 0)
                throw new ArgumentException("Valor monetário não pode ser negativo");

            Valor = valor;
        }

        public string Formatado()
        {
            return $"R$ {Valor.ToString("N2")}";
        }

    }
}
