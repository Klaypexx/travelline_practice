IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'rooms')
CREATE TABLE dbo.rooms 
(
	room_id INT IDENTITY(1,1) NOT NULL,
	room_number INT NOT NULL,
	room_type NVARCHAR(50) NOT NULL,
	price_per_night MONEY NOT NULL,
	availability BIT NOT NULL,
	CONSTRAINT PK_rooms_id_room PRIMARY KEY(room_id)
)

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'customers')
CREATE TABLE dbo.customers
(
	customer_id INT IDENTITY(1,1) NOT NULL,
	first_name NVARCHAR(50) NOT NULL,
	last_name NVARCHAR(50) NOT NULL,
	email NVARCHAR(50) NOT NULL,
    phone_number NVARCHAR(50) NOT NULL,
	CONSTRAINT PK_customers_id_customer PRIMARY KEY(customer_id)
)

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'bookings')
CREATE TABLE dbo.bookings
(
	booking_id INT IDENTITY(1,1) NOT NULL,
	customer_id INT NOT NULL,
	room_id INT NOT NULL,
	check_in_date DATE NOT NULL,
    check_out_date DATE NOT NULL,
	CONSTRAINT PK_bookings_id_booking PRIMARY KEY(booking_id),
	CONSTRAINT FK_bookings_id_customer
	FOREIGN KEY (customer_id) REFERENCES dbo.customers (customer_id),
	CONSTRAINT FK_bookings_id_room
	FOREIGN KEY (room_id) REFERENCES dbo.rooms (room_id)
)

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'facilities')
CREATE TABLE dbo.facilities
(
	facility_id INT IDENTITY(1,1) NOT NULL,
	facility_name NVARCHAR(50) NOT NULL,
	CONSTRAINT PK_facilities_id_facility PRIMARY KEY(facility_id)
)

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'room_to_facilities')
CREATE TABLE dbo.room_to_facilities
(
	room_id INT NOT NULL,
	facility_id INT NOT NULL,
	CONSTRAINT PK_roomtofacilities_id_roomtofacilities PRIMARY KEY(room_id, facility_id),
	CONSTRAINT FK_roomtofacilities_id_room
	FOREIGN KEY (room_id) REFERENCES dbo.rooms(room_id),
	CONSTRAINT FK_roomtofacilities_id_facilities
	FOREIGN KEY (facility_id) REFERENCES dbo.facilities(facility_id)
)

INSERT INTO dbo.rooms (room_number, room_type, price_per_night, availability)
VALUES
    (101, N'Standard', 1000.00, 1),
    (102, N'Standard', 1000.00, 1),
    (103, N'Standard', 1000.00, 1),
    (201, N'Superior', 2000.00, 1),
    (202, N'Superior', 2000.00, 1),
    (203, N'Superior', 2000.00, 1),
    (301, N'Deluxe', 5000.00, 1),
    (302, N'Deluxe', 5000.00, 1),
    (303, N'Deluxe', 5000.00, 1)

INSERT INTO dbo.customers (first_name, last_name, email, phone_number)
VALUES
    (N'John', N'Doe', N'johndoe@gmail.com', N'+7 (495) 123-45-67'),
	(N'Katherine', N'Smith', N'katherinesmith@mail.ru', N'+7 (812) 987-65-43'),
	(N'Alexander', N'Johnson', N'alexanderjohnson@yahoo.com', N'+7 (3832) 345-67-89'),
	(N'Maria', N'Williams', N'mariawilliams@hotmail.com', N'+7 (495) 678-90-12'),
	(N'Dmitry', N'Sokolov', N'dmitrysokolov@outlook.com', N'+7 (8432) 456-78-90'),
	(N'Anna', N'Kuznetsova', N'annakuznetsova@mail.ru', N'+7 (495) 111-22-33'),
	(N'Maxim', N'Fedorov', N'maximfedorov@yahoo.com', N'+7 (812) 444-55-66'),
	(N'Elena', N'Solovieva', N'elenasolovieva@gmail.com', N'+7 (3832) 777-88-99'),
	(N'Sergey', N'Pavlov', N'sergeypavlov@hotmail.com', N'+7 (495) 999-00-11');

INSERT INTO dbo.bookings (customer_id, room_id, check_in_date, check_out_date)
VALUES
    (1, 1, '2024-04-07', '2024-04-08'),
    (2, 2, '2024-04-09', '2024-04-12'),
    (3, 3, '2024-04-10', '2024-04-11'),
    (4, 4, '2024-04-07', '2024-04-15'),
    (5, 5, '2024-04-15', '2024-04-17'),
    (6, 6, '2024-04-20', '2024-04-28'),
    (7, 7, '2024-04-15', '2024-04-20'),
    (8, 8, '2024-04-08', '2024-04-14'),
    (9, 9, '2024-04-13', '2024-04-15')

INSERT INTO dbo.facilities (facility_name)
VALUES
	(N'Wifi'),
	(N'Minibar'),
	(N'Conditioner'),
	(N'Jacuzzi'),
	(N'Hairdryer'),
	(N'Wake-up service'),
	(N'Dry cleaning service'),
	(N'Pets allowed');

INSERT INTO dbo.room_to_facilities (room_id, facility_id)
VALUES
	(1,1),
	(1,2),
	(1,8),
	(2,1),
	(2,2),
	(2,8),
	(3,1),
	(3,2),
	(3,8),
	(4,1),
	(4,2),
	(4,3),
	(4,5),
	(4,8),
	(5,1),
	(5,2),
	(5,3),
	(5,5),
	(5,8),
	(6,1),
	(6,2),
	(6,3),
	(6,5),
	(6,8),
	(7,1),
	(7,2),
	(7,3),
	(7,4),
	(7,5),
	(7,6),
	(7,7),
	(8,1),
	(8,2),
	(8,3),
	(8,4),
	(8,5),
	(8,6),
	(8,7),
	(9,1),
	(9,2),
	(9,3),
	(9,4),
	(9,5),
	(9,6),
	(9,7);