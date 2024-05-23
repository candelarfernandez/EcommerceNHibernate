namespace EcommerceNHibernate.Domain.Entidades
{
    public class Product
    {
        public virtual int IdProduct { get; set; }
        public virtual string NameProduct { get; set; }
        public virtual decimal Price { get; set; }
        public virtual int Stock { get; set; }
        public virtual int IdBrand { get; set; }
        public virtual int IdSubCategory { get; set; }
        public virtual int IdCategory { get; set; }

    }
}
