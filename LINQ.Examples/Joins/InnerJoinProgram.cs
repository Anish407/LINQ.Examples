
var innerJoinWithGroup = from b in Buyer.Buyers
                join s in Supplier.Suppliers 
                on b.District equals s.District
                group s by s.District  into g
                select new {
                    g.Key,
                    data = g.Select(i=> new { 
                     i.SupplierName,
                     i.District,
                     i.SupplierAge,
                    })
                };

var innerJoin = from b in Buyer.Buyers
                         join s in Supplier.Suppliers
                         on b.District equals s.District
                         select new
                         {
                           b.District,
                           b.Name,
                           s.SupplierName,
                           s.SupplierAge
                         };

// join with more than 1 keys
var compositeJoin = from b in Buyer.Buyers
                    join s in Supplier.Suppliers
                    on new { b.Age, b.District } equals new { Age = s.SupplierAge, s.District }
                    select new 
                    {
                        b.Name,
                        supplierName= s.SupplierName,
                        b.Age,
                        b.District
                    };

// all suppliers for that buyer
var groupByJoin = from b in Buyer.Buyers
                  join s in Supplier.Suppliers
                  on b.District equals s.District into SuppliersGroup
                  select new
                  {
                      b.Name,
                      b.District,
                      // all suppliers for that buyer
                      data= SuppliersGroup
                  };
                  
                  

               



Console.ReadLine();

