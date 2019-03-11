using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PiPA.Models.ViewModels
{
    /// <summary>
    /// Defines the <see cref="ExternalLoginViewModel" />
    /// </summary>
    public class ExternalLoginViewModel
    {
        /// <summary>
        /// Gets or sets the Email
        /// </summary>
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the firstName
        /// </summary>
        [Required]
        public string firstName { get; set; }

        /// <summary>
        /// Gets or sets the lastName
        /// </summary>
        [Required]
        public string lastName { get; set; }
    }
}
