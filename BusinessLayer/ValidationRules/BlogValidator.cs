using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog adı boş geçilemez.");
            RuleFor(x => x.BlogTitle).MaximumLength(25).WithMessage("Blog adı 24 karakteri geçemez.");
            RuleFor(x => x.BlogTitle).MinimumLength(3).WithMessage("Blog adı 24 karakteri geçemez.");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Blog resmi boş geçilemez.");          
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Blog içeriği boş geçilemez.");          
            RuleFor(x => x.BlogContent).MinimumLength(5).WithMessage("Blog içeriği en az 5 karakter olmalıdır.");          
        }
    }
}
