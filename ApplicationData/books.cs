//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace library.ApplicationData
{
    using System;
    using System.Collections.Generic;
    
    public partial class books
    {
        public books()
        {
            this.favourites = new HashSet<favourites>();
            this.journal = new HashSet<journal>();
        }
    
        public int ID_bk { get; set; }
        public string name { get; set; }
        public Nullable<int> quantity { get; set; }
        public Nullable<int> year_of_public { get; set; }
        public Nullable<int> ID_a { get; set; }
        public Nullable<int> ID_g { get; set; }
        public Nullable<int> ID_pg { get; set; }
        public Nullable<int> ID_tl { get; set; }
        public Nullable<int> ID_bg { get; set; }
        public string image { get; set; }
    
        public virtual authors authors { get; set; }
        public virtual binding binding { get; set; }
        public virtual genres genres { get; set; }
        public virtual publishing publishing { get; set; }
        public virtual t_of_literature t_of_literature { get; set; }
        public virtual ICollection<favourites> favourites { get; set; }
        public virtual ICollection<journal> journal { get; set; }
    }
}
