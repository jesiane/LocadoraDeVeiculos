﻿using FluentValidation;
using FluentValidation.Validators;

namespace LocadoraDeVeiculos.Dominio.Compartilhado
{
    public class PodeApenasLetrasValidator<T> : PropertyValidator<T, string>
    {
        public override string Name => "PodeApenasLetrasValidator";

        private string nomePropriedade;

        protected override string GetDefaultMessageTemplate(string errorCode)
        {            
            return $"'{nomePropriedade}' deve ser composto por apenas letras.";
        }

        public override bool IsValid(ValidationContext<T> contextoValidacao, string texto)
        {
            nomePropriedade = contextoValidacao.DisplayName;

            if (string.IsNullOrEmpty(texto))
                return false;

            bool estaValido = true;

            foreach (char letra in texto)
            {
                if (letra == ' ')
                    continue;

                if (char.IsLetter(letra) == false)
                {
                    estaValido = false;                    
                    break;
                }
            }

            return estaValido;
        }        
    }
}
