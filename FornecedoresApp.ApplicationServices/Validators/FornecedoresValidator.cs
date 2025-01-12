using FluentValidation;
using FornecedoresApp.ApplicationModels.Entities;

namespace FornecedoresApp.ApplicationServices.Validators
{
    public class FornecedoresValidator : AbstractValidator<FornecedoresRequest>
    {
        public FornecedoresValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress();
            RuleFor(x => x.NomeResponsavel)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.CNPJ)
                .NotEmpty()
                .NotNull()
                .Must(IsValidCnpj)
                .WithMessage("CPNJ Inválido");
            RuleFor(x => x.Telefone)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.Endereco)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.Cidade)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.Estado)
                .NotEmpty()
                .NotNull()
                .MaximumLength(2);
            RuleFor(x => x.CEP)
                .NotEmpty()
                .NotNull();
        }

        public static bool IsValidCnpj(string cnpj)
        {
            if (string.IsNullOrWhiteSpace(cnpj)) return false;

            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

            if (cnpj.Length != 14 || !long.TryParse(cnpj, out _)) return false;

            if (new string(cnpj[0], cnpj.Length) == cnpj) return false;

            int[] multiplicador1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCnpj = cnpj.Substring(0, 12);
            int soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            int resto = (soma % 11);
            if (resto < 2) resto = 0;
            else resto = 11 - resto;

            string digito = resto.ToString();
            tempCnpj += digito;
            soma = 0;

            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);
            if (resto < 2) resto = 0;
            else resto = 11 - resto;

            digito += resto.ToString();

            return cnpj.EndsWith(digito);
        }
    }
}
