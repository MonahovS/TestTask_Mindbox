/// Предположим у нас заданы 3 таблицы со столбцами
/// Products
/// - id
/// - caption
/// Categories
/// - id
/// - caption
/// Links
/// - productID
/// - categoryID

/*
SELECT Products.caption, Categories.caption
FROM Products, Categories, Links
WHERE Links.productID = Products.id AND
      Links.categoryID = Categories.id
UNION
SELECT Products.caption, ''
FROM Products, Links
WHERE Products.id NOT IN
    (SELECT Links.productID FROM Links)

*/