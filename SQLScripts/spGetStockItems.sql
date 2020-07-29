SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE spGetStockItems 
AS
BEGIN
	SET NOCOUNT ON;

	SELECT s.StockItemName, sup.SupplierName, pt.PackageTypeName, s.UnitPrice
	FROM Warehouse.StockItems s
	JOIN Purchasing.Suppliers sup ON s.SupplierID = sup.SupplierID
	JOIN Warehouse.PackageTypes pt ON s.UnitPackageID = pt.PackageTypeID
END
GO
