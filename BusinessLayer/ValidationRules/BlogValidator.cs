using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTittle).NotEmpty().WithMessage("Blog başlığını boş bırakamazsınız.")
                .MinimumLength(5).WithMessage("Lütfen en az 5 karakter giriniz.")
                .MaximumLength(100).WithMessage("Lütfen en fazla 100 karakter giriniz.");

            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Blog içeriğini boş bırakamazsınız.")
                .MinimumLength(200).WithMessage("Lütfen en az 200 karakter giriniz.");

            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Blog görselini boş bırakamazsınız.");

            RuleFor(x => x.BlogThumbnailImage).NotEmpty().WithMessage("Blog küçük görsel alanını boş bırakamazsınız.");

            RuleFor(x => x.CategoryID).NotEmpty().WithMessage("Lütfen bir kategori seçiniz.");
        }
    }
}
