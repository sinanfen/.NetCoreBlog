using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori adı boş geçilemez.")
                .MaximumLength(200).WithMessage("En fazla 200 karakter girebilirsiniz.")
                .MinimumLength(5).WithMessage("En az 5 karakter girebilirsiniz");

            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Kategori açıklaması boş geçilemez.")                
                .MinimumLength(20).WithMessage("En az 20 karakter girebilirsiniz");
        }
    }
}
