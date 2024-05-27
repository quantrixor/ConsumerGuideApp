//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsumerGuideApp.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Services
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Services()
        {
            this.Companies = new HashSet<Companies>();
        }
    
        public int ServiceID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<int> ServiceCategoryID { get; set; }
    
        public virtual ServiceCategories ServiceCategories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Companies> Companies { get; set; }
        public virtual ICollection<CompanyService> CompanyServices { get; set; } = new List<CompanyService>();

    }
}