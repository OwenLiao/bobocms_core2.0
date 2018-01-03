
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace bobo.entity
{

    public partial class Manager
    {
        public Manager()
        {
            this.AddTime = DateTime.Now;
        }

        /// <summary>ss
        ///
        /// </summary>

        public int Id { get; set; }

        /// <summay>
        ///��ɫid
        /// </summary>
        [Display(Name = "��ɫ")]
        [Required]
        public int roleId { get; set; }

        /// <summary>
        ///
        /// </summary>

        public Nullable<int> RoleType { get; set; }

        /// <summary>
        ///�ʺ�
        /// </summary>
        [Display(Name = "�ʺ�")]
        [Required]
        public string UserName { get; set; }

        /// <summary>
        ///����
        /// </summary>
        [Display(Name = "����")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "����{2}���ַ�")]
        [Required]
        public string UserPwd { get; set; }

        /// <summary>
        ///����
        /// </summary>
        [Display(Name = "����")]
        public string RealName { get; set; }

        /// <summary>
        ///
        /// </summary>

        public string Telephone { get; set; }

        /// <summary>
        ///
        /// </summary>

        public string Email { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Display(Name = "״̬")]
        public Nullable<int> IsLock { get; set; }


        public Nullable<int> IsDeleted { get; set; }

        /// <summary>
        ///
        /// </summary>

        public Nullable<System.DateTime> AddTime { get; set; }

        
        public  ManagerRole ManagerRole { get; set; }
    }
}
