USE tagis;
# INSERT INTO company(company_title, machine_name, logo, address1, address2, city, state, zip, contact_name, contact_email, contact_phone, website, company_store) VALUES ('The Advent Group', 'the_advent_group', 'http://theadventgroup.net/wp-content/uploads/2015/05/AdventLogoWeb.png', '9665 S Sandy Parkway', '', 'Sandy', 'UT', '84070', 'Kandace Dato', 'kdato@theadventgroup.net', '800-939-8781', 'http://theadventgroup.net', 'http://adventstores.com');
INSERT INTO company(company_title, machine_name, logo, address1, address2, city, state, zip, contact_name, contact_email, contact_phone, website) VALUES ('LoganFarr.com', 'loganfarr_com', 'http://theadventgroup.net/wp-content/uploads/2015/05/AdventLogoWeb.png', '10614 S 1090 E', '', 'Sandy', 'UT', '84094', 'Logan Farr', 'Logan@loganfarr.com', '435-773-5793', 'http://loganfarr.com');
INSERT INTO products(sku, product_title, stock, company) VALUES('test-product-1', 'Test product 1', 5, 1);
INSERT INTO productS(sku, product_title, stock, company) VALUES('test-product-2', 'Test product 2', 10, 2);
INSERT INTO orders(order_status, created_date, last_modified_date, products, subtotal, total, company, order_source, customer_name, customer_email, customer_phone, customer_address1, customer_address2, customer_city, customer_state, customer_zip, shipping_number, shipping_carrier) VALUES('new', '2017-08-27', '', '[{"sku": "test-product-1", "quantity": 5}, {"sku": "test-product-2", "quantity": 3}]', '12.59', '15.23', 1, 'TAGIS', 'Logan Farr', 'Logantf17@gmail.com', '435-773-5793', '10614 S 1090 E', '', 'Sandy', 'UT', '84094', '1234567', 'USPS');

UPDATE tagis.products SET stock=20;

SELECT * FROM products;
SELECT * FROM orders;
SELECT * FROM users;
SELECT * FROM company;
SELECT * FROM user_roles ORDER BY _rid;

UPDATE users SET role=1, company='2' WHERE _uid = 1;
SELECT * FROM company WHERE (company=2)