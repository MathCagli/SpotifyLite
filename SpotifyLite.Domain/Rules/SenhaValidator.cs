using FluentValidation;
using SpotifyLite.Domain.ValueObject;
using System.Text.RegularExpressions;

namespace SpotifyLite.Domain.Rules
{
    public class SenhaValidator : AbstractValidator<Senha>
    {
        private const string Pattern = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$";

        public SenhaValidator()
        {
            RuleFor(x => x.Valor)
                .NotEmpty()
                .Must(BeValidSenha).WithMessage("A senha deve ter no mínimo 8 caracteres, uma letra, um caracter especial e um número.");
        }

        private bool BeValidSenha(string valor) => Regex.IsMatch(valor, Pattern);
    }
}
