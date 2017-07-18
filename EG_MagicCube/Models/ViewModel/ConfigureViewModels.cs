using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace EG_MagicCube.Models.ViewModel
{
    public class ConfigureViewModels
    {
        [Display(Name = "無包裝內容時要顯示的內文", Prompt = "")]
        [Required(ErrorMessage = "無包裝內容時要顯示的內文")]
        public string EmptyContent { get; set; } = "";
        [Display(Name = "發生錯時時要顯示的內文", Prompt = "")]
        [Required(ErrorMessage = "發生錯時時要顯示的內文")]
        public string ErrorContent { get; set; } = "";
        [Display(Name = "包裝預設開放的天數", Prompt = "")]
        [Required(ErrorMessage = "包裝預設開放的天數")]
        public string OpenDays { get; set; } = "";
    }
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class AllowHtmlAttribute : Attribute, IMetadataAware
    {
        // Methods
        public void OnMetadataCreated(ModelMetadata metadata)
        {
            if (metadata == null)
            {
                throw new ArgumentNullException("metadata");
            }
            metadata.RequestValidationEnabled = false;
        }
    }

}