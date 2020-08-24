

CREATE or alter PROCEDURE Get_AllSize
AS
	select SizeID, Name  from tblSize
GO

CREATE or alter  PROCEDURE Get_AllIngredients
AS
	select IngredientsId, Name, Price  from tblIngredients
GO

use PanPizzaDB