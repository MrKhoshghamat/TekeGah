using System.ComponentModel.DataAnnotations;

namespace TekeGah.Application.Models.ViewModels;

public class UserRegisterViewModel
{
    [Display(Name = "شماره تماس")]
    [MaxLength(20, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد.")]
    public string Mobile { get; set; }
}