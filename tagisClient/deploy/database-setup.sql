
# Create the TAGIS database if it doesn't exist
DROP DATABASE IF EXISTS tagis;
CREATE DATABASE tagis;
USE tagis;

# Create table for company
DROP TABLE IF EXISTS company;
CREATE TABLE company(
  _cid MEDIUMINT UNSIGNED NOT NULL AUTO_INCREMENT UNIQUE,
  company_title VARCHAR(500) NOT NULL UNIQUE,
  machine_name VARCHAR(600) NOT NULL UNIQUE,
  logo VARCHAR(1000),
  address1 VARCHAR(1000),
  address2 VARCHAR(500),
  city VARCHAR(200),
  state VARCHAR(100),
  zip VARCHAR(10),
  contact_name VARCHAR(200),
  contact_email VARCHAR(500),
  contact_phone VARCHAR(20),
  website VARCHAR(1000),
  company_store VARCHAR(1000),
  api_endpoint VARCHAR(1000),
  emails_enabled BOOLEAN DEFAULT 0,
  email_from_address VARCHAR(1000),
  discount VARCHAR(1000),
  coupon_code VARCHAR(1000),
  receipt_email MEDIUMINT UNSIGNED,
  shipping_notification_email MEDIUMINT UNSIGNED,
  thank_you_email MEDIUMINT UNSIGNED,
  coupon_email MEDIUMINT UNSIGNED,
  PRIMARY KEY (_cid)
);

# Create table for products
DROP TABLE IF EXISTS products;
CREATE TABLE products(
  _pid MEDIUMINT UNSIGNED NOT NULL AUTO_INCREMENT UNIQUE,
  sku VARCHAR(500) NOT NULL UNIQUE,
  product_title VARCHAR(500) NOT NULL,
  stock MEDIUMINT DEFAULT 0,
  company MEDIUMINT UNSIGNED, #Reference to company table
  image VARCHAR(500),
  PRIMARY KEY (_pid),
  FOREIGN KEY (company) REFERENCES company(_cid)
);

# Create table for orders
DROP TABLE IF EXISTS orders;
CREATE TABLE orders(
  _oid MEDIUMINT UNSIGNED NOT NULL AUTO_INCREMENT UNIQUE,
  order_status VARCHAR(20) DEFAULT 'new',
  created_date TIMESTAMP,
  last_modified_date TIMESTAMP,
  products TEXT(65000),
  subtotal DECIMAL(8,2),
  taxes DECIMAL(6,2),
  shipping_fees DECIMAL(8,2),
  total DECIMAL(8,2),
  company MEDIUMINT UNSIGNED NOT NULL,
  order_source VARCHAR(1000),
  customer_name VARCHAR(1000) NOT NULL,
  customer_email VARCHAR(100) NOT NULL,
  customer_phone VARCHAR(20),
  customer_address1 VARCHAR(1000) NOT NULL,
  customer_address2 VARCHAR(500),
  customer_city VARCHAR(200) NOT NULL,
  customer_state VARCHAR(100) NOT NULL,
  customer_zip VARCHAR(10) NOT NULL,
  shipping_name VARCHAR(1000),
  shipping_address1 VARCHAR(1000),
  shipping_address2 VARCHAR(500),
  shipping_city VARCHAR(200), 
  shipping_state VARCHAR(100),
  shipping_zip VARCHAR(10),
  ref VARCHAR(1000),
  shipping_number VARCHAR(500),
  shipping_carrier VARCHAR(500),
  receipt_email_sent TIMESTAMP,
  shipping_email_sent TIMESTAMP,
  coupon_email_sent TIMESTAMP,
  order_notification_sent TIMESTAMP,
  receipt_email_id VARCHAR(1000),
  shipping_notification_id VARCHAR(1000),
  coupon_email_id VARCHAR(1000),
  order_notification_id VARCHAR(1000),
  PRIMARY KEY (_oid),
  FOREIGN KEY (company) REFERENCES company(_cid)
);

# Create table for email settings
DROP TABLE IF EXISTS emails;
CREATE TABLE emails(
  _eid MEDIUMINT UNSIGNED NOT NULL AUTO_INCREMENT UNIQUE,
  emails_enabled BOOLEAN DEFAULT 0,
  company MEDIUMINT UNSIGNED NOT NULL, 
  email_key VARCHAR(100), 
  subject_line VARCHAR(150),
  prehead VARCHAR(30),
  body MEDIUMBLOB,
  PRIMARY KEY (_eid), 
  FOREIGN KEY (company) REFERENCES company(_cid)
);

# Create table for user roles 
DROP TABLE IF EXISTS user_roles;
CREATE TABLE user_roles(
  _rid MEDIUMINT UNSIGNED NOT NULL AUTO_INCREMENT UNIQUE,
  role_name VARCHAR(100) NOT NULL UNIQUE,
  PRIMARY KEY (_rid)
);

# Create table for users
DROP TABLE IF EXISTS users;
CREATE TABLE users(
  _uid MEDIUMINT UNSIGNED NOT NULL AUTO_INCREMENT UNIQUE,
  email VARCHAR(700) NOT NULL UNIQUE,
  first_name VARCHAR(100), 
  last_name VARCHAR(100),
  password VARCHAR(1000),
  active BOOLEAN DEFAULT 1,
  last_login DATETIME,
  profile_picture VARCHAR(700),
  company TEXT(1000),
  role MEDIUMINT UNSIGNED NOT NULL DEFAULT 2, 
  PRIMARY KEY (_uid),
  FOREIGN KEY (role) REFERENCES user_roles(_rid)
);

# Add foreign key references
ALTER TABLE company ADD FOREIGN KEY (receipt_email) REFERENCES emails(_eid);
ALTER TABLE company ADD FOREIGN KEY (shipping_notification_email) REFERENCES emails(_eid);
ALTER TABLE company ADD FOREIGN KEY (thank_you_email) REFERENCES emails(_eid);

# Create user roles
INSERT INTO user_roles(role_name) VALUES('admin');
INSERT INTO user_roles(role_name) VALUES('employee');
INSERT INTO user_roles(role_name) VALUES('guest');
INSERT INTO user_roles(role_name) VALUES('customer');

# Load default admin user
INSERT INTO users(email, first_name, last_name, password, active, role) VALUES('logan@loganfarr.com', 'Logan', 'Farr', 'sha1$d1d52a02$1$58a2097161b47d09cb2f95d506a8dc25740c9460', 1, 1);

# Create company #1
INSERT INTO company(company_title, machine_name, logo, address1, address2, city, state, zip, contact_name, contact_email, contact_phone, website, company_store, email_from_address) VALUES ('The Advent Group', 'the_advent_group', 'https://s3-us-west-2.amazonaws.com/the-advent-group/tagis/company-logos/logo.png', '9665 S Sandy Parkway', '', 'Sandy', 'UT', '84070', 'Shaantai Leary', 'Shaantai@theadventgroup.net', '801-214-9738x3037', 'http://theadventgroup.net', 'https://base.adventstores.com', 'support@adventstores.com');