using System;

internal class Supplier
{
    public string SupplierName { get; set; }
    public string District { get; set; }
    public int SupplierAge { get; set; }

    public static List<Supplier> Suppliers => new List<Supplier>()
            {
                new Supplier() { SupplierName = "Harrison", District = "Fantasy District",   SupplierAge = 22 },
                new Supplier() { SupplierName = "Charles", District = "Developers District", SupplierAge = 40 },
                new Supplier() { SupplierName = "Hailee", District = "Scientists District",  SupplierAge = 35 },
                new Supplier() { SupplierName = "Taylor", District = "EarthIsFlat District", SupplierAge = 30 }
            };
}

internal class Buyer
{
    public string Name { get; set; }
    public string District { get; set; }
    public int Age { get; set; }

    public static List<Buyer> Buyers => new List<Buyer>()
    {
                new Buyer() { Name = "Johny", District = "Fantasy District", Age = 22},
                new Buyer() { Name = "Peter", District = "Scientists District", Age = 40},
                new Buyer() { Name = "Paul", District = "Fantasy District", Age = 30 },
                new Buyer() { Name = "Maria", District = "Scientists District", Age = 35 },
                new Buyer() { Name = "Joshua", District = "EarthIsFlat District", Age = 40 },
                new Buyer() { Name = "Sylvia", District = "Developers District", Age = 22 },
                new Buyer() { Name = "Rebecca", District = "Scientists District", Age = 30 },
                new Buyer() { Name = "Jaime", District = "Developers District", Age = 35 },
                new Buyer() { Name = "Pierce", District = "Fantasy District", Age = 40 }
    };

    public static List<Buyer> BuyersLeftJoin => new List<Buyer>()
    {
                new Buyer() { Name = "Johny", District = "Fantasy District", Age = 22},
                new Buyer() { Name = "Peter", District = "Scientists District", Age = 40},
                new Buyer() { Name = "Paul", District = "Fantasy District", Age = 30 },
                new Buyer() { Name = "Maria", District = "Scientists District", Age = 35 },
                new Buyer() { Name = "Rebecca", District = "Scientists District", Age = 30 },
                new Buyer() { Name = "Pierce", District = "Fantasy District", Age = 40 }
    };
}
