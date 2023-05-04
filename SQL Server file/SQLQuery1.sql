Create database ABC_Healthcare;
use ABC_Healthcare;
/*drop database ABC_Healthcare*/


create Table Product_Category (
  id int Primary Key IDENTITY(1,1),
  Name varchar(50) NOT NULL,
  Description varchar(100) NOT NULL,
  Enabled bit NOT NULL
)

Create Table Seller (
  id integer primary key identity(1,1) not null,
  Name varchar(50) not null,
  Description varchar(50)  not null, 
  address varchar(100)  not null
)

Create Table Product (
  id integer primary key not null identity(1,1),
  Name varchar(50) not null,
  Image varchar(100) not null,
  Description varchar(100) not null,
  Short_description varchar(50) not null,
  SKU varchar(50) not null,
  Category_id integer  not null ,
  Quantity integer not null,
  MRP decimal not null,
  Selling_price decimal  not null,
  Enabled bit not null,
  Seller_id integer not null 
)


Create Table DiscountOn_cart (
  id integer primary key identity(1,1) not null,
  Name varchar(50) not null,
  Description varchar(50) not null,
  Discount_amount integer  not null,
  Active bit  not null,
  isPercentage bit  not null,
  min_cart_value integer  not null
)


Create Table DiscountOn_product (
  id integer primary key identity(1,1) not null,
  Name varchar(50) not null,
  Description varchar(50) not null,
  Discount_amount integer  not null,
  Active bit  not null,
  isPercentage bit  not null,
  min_cart_value integer  not null
)

Create Table DiscountOn_category (
  id integer primary key identity(1,1) not null,
  Name varchar(50) not null,
  Description varchar(50) not null,
  Discount_amount integer  not null,
  Active bit  not null,
  isPercentage bit  not null,
  min_cart_value integer  not null
)

Create Table Customer (
  id integer primary key identity(1,1) not null,
  first_name varchar(50) not null,
  last_name varchar(50) not null,
  email varchar(50) not null,
  password varchar(50) not null,
  phone_no integer not null
)

Create Table Customer_Address(
  id integer primary key identity(1,1) not null,
  customer_id integer not null,
  first_name varchar(50) not null,
  last_name varchar(50) not null,
  address_line1 varchar(50) not null,
  address_line2 varchar(100) not null,
  city varchar(50) not null,
  state varchar(50) not null,
  landmark varchar(100) not null,
  pincode integer not null,
  country varchar not null,
  mobile_no integer not null,
  isHome bit not null,
  isOffice bit not null
)
/*
create Table Admin_type (
  id integer primary key not null identity(1,1),
  admin_type varchar(50) not null,
  permission varchar(50) not null
)
*/
Create table Admin_User (
  id integer primary key not null identity(1,1),
  username varchar(50) not null,
  password varchar(50) not null,
  first_name varchar(50) not null,
  last_name varchar(50) not null,
  admin_type_id integer not null 
)

create Table Order_Details(
  id integer primary key identity(1,1) not null,
  customer_id integer not null,
  total decimal not null,
  discount decimal not null,
  final_price decimal not null,
  product_list varchar(50) not null
)

create Table Cart(
  id integer primary key not null identity(1,1),
  customer_id integer not null,
  product_list varchar(50) not null,
  total decimal not null,
  discount decimal not null,
  final_price decimal not null
)



