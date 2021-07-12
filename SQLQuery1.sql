CREATE VIEW OrderView AS
SELECT        ico.IceCreamOrderId AS OrderViewId, ico.IceCreamOrderId, ico.CustomerId, f.FlavorName, f.Price AS FlavorPrice, t.Price AS ToppingPrice, f.Price + t.Price AS Price, c.CustomerName, c.Payment
FROM            dbo.IceCreamOrder AS ico INNER JOIN
                         dbo.Customer AS c ON ico.CustomerId = c.CustomerId INNER JOIN
                         dbo.Flavor AS f ON ico.FlavorId = f.FlavorId INNER JOIN
                         dbo.Topping AS t ON ico.ToppingsId = t.ToppingId