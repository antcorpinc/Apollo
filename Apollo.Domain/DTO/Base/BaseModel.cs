using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Apollo.Domain.DTO.Base
{
    public abstract class BaseModel
    {
       
        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public string UpdatedBy { get; set; }

        private DateTime _createdDate;

        private DateTime _updatedDate;

        public DateTime CreatedDate
        {
            get
            {

                if (_createdDate == DateTime.MinValue)
                {
                    return DateTime.Now.ToUniversalTime();
                }
                else
                {
                    return _createdDate;
                }
            }
            set {
                _createdDate = value;
            }
        }

        public DateTime UpdatedDate
        {
            get
            {
                if (_updatedDate == DateTime.MinValue)
                {   
                    return DateTime.Now.ToUniversalTime();
                }
                else
                {
                    return _updatedDate;
                }
            }
            set {
                _updatedDate = value;
            }
        }
    }

    public abstract class BaseModelWithActive : BaseModel
    {
        [Required]
        public bool IsActive { get; set; }
    }
}
