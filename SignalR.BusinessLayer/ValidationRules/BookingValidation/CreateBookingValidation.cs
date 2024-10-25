using FluentValidation;
using SignalR.DtoLayer.BookingDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.ValidationRules.BookingValidation
{
    public class CreateBookingValidation : AbstractValidator<CreateBookingDto>
    {
        public CreateBookingValidation()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Lütfen bir isim giriniz.");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Lütfen bir telefon numarası giriniz.");
            RuleFor(x => x.EMail).NotEmpty().WithMessage("Lütfen bir mail adresi giriniz.");
            RuleFor(x => x.NumberOfGuests).NotEmpty().WithMessage("Lütfen konuk sayısını giriniz.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Lütfen bir soyad giriniz.");
            RuleFor(x => x.Date).NotEmpty().WithMessage("Lütfen bir tarih giriniz.");

            RuleFor(x => x.FirstName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter giriniz.");
            RuleFor(x => x.FirstName).MaximumLength(30).WithMessage("Lütfen en fazla 30 karakter giriniz.");
            RuleFor(x => x.LastName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter giriniz.");
            RuleFor(x => x.LastName).MaximumLength(30).WithMessage("Lütfen en fazla 30 karakter giriniz.");
            RuleFor(x => x.Description).MaximumLength(200).WithMessage("Lütfen en fazla 200 karakter giriniz.");

            RuleFor(x => x.EMail).EmailAddress().WithMessage("Lütfen geçerli bir mail adresi giriniz.");
            RuleFor(x => x.PhoneNumber).Length(11).WithMessage("Lütfen telefon numaranızı başında 0 bulunacak şekilde 11 karakter olarak giriniz.");
        }
    }
}
