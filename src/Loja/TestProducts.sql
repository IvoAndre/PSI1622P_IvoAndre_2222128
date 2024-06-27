-- Insert test categories
INSERT INTO shop_categories (name) VALUES ('Category 1');
INSERT INTO shop_categories (name) VALUES ('Category 2');
INSERT INTO shop_categories (name) VALUES ('Category 3');

-- Insert products for Category 1
DECLARE @i INT = 1;
WHILE @i <= 15
BEGIN
    INSERT INTO shop_products (idcat, catpos, name, description, stock, price)
    VALUES (1, @i, 'Product ' + CAST(@i AS VARCHAR), 'Description of Product ' + CAST(@i AS VARCHAR), 100, 10.00);
    SET @i = @i + 1;
END;

-- Insert products for Category 2 with descriptions longer than 200 characters
SET @i = 1;
WHILE @i <= 10
BEGIN
    DECLARE @description VARCHAR(500);
    SET @description = REPLICATE('Description of Product ' + CAST(@i AS VARCHAR), 50); -- Each description will have more than 200 characters

    INSERT INTO shop_products (idcat, catpos, name, description, stock, price)
    VALUES (2, @i, ' Product ' + CAST(@i AS VARCHAR), @description, 100, 10.00);
    
    SET @i = @i + 1;
END;
