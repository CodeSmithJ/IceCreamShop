Create VIEW [dbo].[OrderView]
	AS SELECT ico.IceCreamOrderId As OrderViewId, ico.IceCreamOrderId , ico.CustomerId, f.FlavorName, f.price AS FlavorPrice,t.price AS ToppingPrice,
	f.price+t.price As Price, c.CustomerName, c.Payment
FROM IceCreamOrder ico 
JOIN Customer c ON ico.customerId = c.customerId
JOIN flavor f ON ico.flavorid = f.flavorid
JOIN topping t ON ico.ToppingsId = t.ToppingId
