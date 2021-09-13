using System;
using System.Linq;

namespace ValidaCpf
{
    public static class ValidaCpfExtension
    {
        private static readonly string[] cpfInvalid =
        {
            "00000000000", "11111111111", "22222222222",
            "33333333333", "44444444444", "55555555555",
            "66666666666", "77777777777", "88888888888", "99999999999"
        };

        public static bool Validate(string CPF)
        {
            var primeiroMultiplicador = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var segundoMultiplicador = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string cpfAuxiliar, digito;
            int soma, resto;
            CPF = CPF.Trim();
            CPF = CPF.Replace(".", "").Replace("-", "");
            if(!long.TryParse(CPF, out var parsed))
                return false;
            if (CPF.Length != 11 || cpfInvalid.Contains(CPF))
                return false;
            cpfAuxiliar = CPF.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(cpfAuxiliar[i].ToString()) * primeiroMultiplicador[i];
            resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;
            digito = resto.ToString();
            cpfAuxiliar = cpfAuxiliar + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(cpfAuxiliar[i].ToString()) * segundoMultiplicador[i];
            resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;
            digito = digito + resto;
            return CPF.EndsWith(digito);
        }
    }
}
