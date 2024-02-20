using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class PortfolioValidator : AbstractValidator<Portfolio>
    {
        public PortfolioValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Proje adini girmek zorundasınız");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Proje ismi 3 karakterden fazla olmalidir");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Proje ismi 50 karakterden fazla olamaz");
            RuleFor(x => x.ImageUrl1).NotEmpty().WithMessage("Görsel girmediniz");
            RuleFor(x => x.ImageUrl2).NotEmpty().WithMessage("Görsel girmediniz");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Fiyat bilgisi girmediniz");
            RuleFor(x => x.Value).NotEmpty().WithMessage("İlerleme oranini belirtmediniz");
        }
    }
}
