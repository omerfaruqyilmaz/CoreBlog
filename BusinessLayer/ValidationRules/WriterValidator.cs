using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı soyadı alanı boş geçilemez.");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail  alanı boş geçilemez.");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre alanı boş geçilemez.");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("En az 2 karakter girişi yapmalısınız.");
            RuleFor(x => x.WriterMail).MinimumLength(2).WithMessage("En az 2 karakter girişi yapmalısınız.");
            RuleFor(x => x.WriterPassword).MinimumLength(2).WithMessage("En az 2 karakter girişi yapmalısınız.");
            RuleFor(x => x.WriterName).MaximumLength(23).WithMessage("En fazla 23 karakter girişi yapmalısınız.");
        }
    }
}
