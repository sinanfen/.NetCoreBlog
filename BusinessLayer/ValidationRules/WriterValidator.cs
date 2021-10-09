using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı ve soyadı alanı boş bırakılamaz.")
                .MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapınız.")
                .MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter girişi yapınız.");

            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail adresi alanı boş bırakılamaz.")
                .EmailAddress().WithMessage("Geçerli bir email adresi giriniz.");

            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre alanı boş bırakılamaz.")
                .MinimumLength(6).WithMessage("En az 6 karakter girişi yapınız.")
                .MaximumLength(32).WithMessage("En fazla 32 karakter girişi yapınız")
                .Matches(@"[A-Z]+").WithMessage("Şifreniz en az bir BÜYÜK harf içermelidir.")
                .Matches(@"[a-z]+").WithMessage("Şifreniz en az bir küçük harf içermelidir.")
                .Matches(@"[0-9]+").WithMessage("Şifreniz en az 1 sayı içermelidir.");
                //.Equal(x => x.WriterPasswordConfirm).WithMessage("Girdiğiniz şifreler eşleşmelidir."); //Equal kullanarak şifre ve şifre onay alanının karşılaştırılması sağlandı.

            RuleFor(x => x.WriterPasswordConfirm).NotEmpty().WithMessage("Şifre onay alanı boş bırakılamaz.")
               .MinimumLength(6).WithMessage("En az 6 karakter girişi yapınız.")
               .MaximumLength(32).WithMessage("En fazla 32 karakter girişi yapınız")
               .Matches(@"[A-Z]+").WithMessage("Şifreniz en az bir BÜYÜK harf içermelidir.")
               .Matches(@"[a-z]+").WithMessage("Şifreniz en az bir küçük harf içermelidir.")
               .Matches(@"[0-9]+").WithMessage("Şifreniz en az 1 sayı içermelidir.")
               .Equal(x => x.WriterPassword).WithMessage("Girdiğiniz şifreler eşleşmelidir."); //Equal kullanarak şifre ve şifre onay alanının karşılaştırılması sağlandı.

            RuleFor(x => x.WriterImage).NotEmpty().WithMessage("Görsel dosya yolu alanı boş bırakılamaz.");

        }
    }
}
