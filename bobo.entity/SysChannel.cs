
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bobo.entity
{

    public partial class SysChannel
    {
        public SysChannel()
        {
            this.ManagerRoleValues = new List<ManagerRoleValue>();
           // this.parentId = 0;
            this.SortId = 99;
        }


        /// <summary>
        ///
        /// </summary>

        public int Id { get; set; }


        /// <summary>
        ///Ƶ������
        /// </summary>
        [Required]
        [Display(Name = "Ƶ������")]
        public string Name { get; set; }

        /// <summary>
        ///Ƶ������
        /// </summary>
        [Required]
        [Display(Name = "Ƶ������")]
        public string Title { get; set; }

        /// <summary>
        ///�ϼ�Ƶ��
        /// </summary>
        [Display(Name = "�ϼ�Ƶ��")]
        public Nullable<int> parentId { get; set; }

        public SysChannel Parent { get; set; }
        public ICollection<SysChannel> Children { get; set; }

        /// <summary>
        ///�����ַ
        /// </summary>
        [Display(Name = "�����ַ")]
        public string LinkUrl { get; set; }

        /// <summary>
        ///
        /// </summary>

        public string ImgUrl { get; set; }

        /// <summary>
        ///
        /// </summary>

        public string Description { get; set; }

        /// <summary>
        ///����
        /// </summary>
        [Display(Name = "����")]
        [Required]
        public Nullable<int> SortId { get; set; }


        public virtual ICollection<ManagerRoleValue> ManagerRoleValues { get; set; }

    }
}
