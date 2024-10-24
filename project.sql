create database Nammametro
use Nammametro
drop database Nammametro

CREATE TABLE Passenger (
    phone_no bigint PRIMARY KEY,
    username VARCHAR(50) NOT NULL
);

-- Create Card Table
CREATE TABLE metrocard (
    card_id INT Identity(1000,1) PRIMARY KEY,
    wallet_balance int NOT NULL DEFAULT 200,
    phone_no bigint,

	constraint phone_foreignkey FOREIGN KEY (phone_no) REFERENCES Passenger ON DELETE CASCADE
);

create trigger trgNewPassenger
on Passenger
after insert
as
begin
	declare @phNo bigint 
	set @phNo = (select i.phone_no from inserted i)
	insert into metrocard(phone_no) values (@phNo)
end
-- Create Station Table
CREATE TABLE Station (
    station_id INT PRIMARY KEY,
    station_name VARCHAR(100) NOT NULL
);

-- Create Booking Table
CREATE TABLE Booking (
    booking_id INT Identity(100,1) PRIMARY KEY,
    source_stn INT,
    destination_stn INT,
    fare INT,
    FOREIGN KEY (source_stn) REFERENCES Station(station_id),
    FOREIGN KEY (destination_stn) REFERENCES Station(station_id),
    
);

drop table Station
drop table Booking

ALTER TABLE Booking
ADD fare INT;



select * from Passenger
select * from metrocard
select * from Booking
select * from Station



INSERT INTO Station (station_id, station_name) VALUES (1, 'Nagasandra');
INSERT INTO Station (station_id, station_name) VALUES (2, 'Dasarahalli');
INSERT INTO Station (station_id, station_name) VALUES (3, 'Jalahalli');
INSERT INTO Station (station_id, station_name) VALUES (4, 'Peenya Industry');
INSERT INTO Station (station_id, station_name) VALUES (5, 'Peenya');
INSERT INTO Station (station_id, station_name) VALUES (6, 'Goraguntepalya');
INSERT INTO Station (station_id, station_name) VALUES (7, 'Yeshwantpur');
INSERT INTO Station (station_id, station_name) VALUES (8, 'Sandal Soap Factory');
INSERT INTO Station (station_id, station_name) VALUES (9, 'Mahalaxmi');
INSERT INTO Station (station_id, station_name) VALUES (10, 'Rajajinagar');
INSERT INTO Station (station_id, station_name) VALUES (11, 'Kuvempu Road');
INSERT INTO Station (station_id, station_name) VALUES (12, 'Shrirampura');
INSERT INTO Station (station_id, station_name) VALUES (13, 'Sampige Road');
INSERT INTO Station (station_id, station_name) VALUES (14, 'Majestic');
INSERT INTO Station (station_id, station_name) VALUES (15, 'Chikpete');
INSERT INTO Station (station_id, station_name) VALUES (16, 'K.R.Market');
INSERT INTO Station (station_id, station_name) VALUES (17, 'National College');
INSERT INTO Station (station_id, station_name) VALUES (18, 'Lalbagh');
INSERT INTO Station (station_id, station_name) VALUES (19, 'South End Circle');
INSERT INTO Station (station_id, station_name) VALUES (20, 'Jayanagar');
INSERT INTO Station (station_id, station_name) VALUES (21, 'R.V.Road');
INSERT INTO Station (station_id, station_name) VALUES (22, 'Banashankari');
INSERT INTO Station (station_id, station_name) VALUES (23, 'Jayaprakash Nagar');
INSERT INTO Station (station_id, station_name) VALUES (24, 'Yelachenahalli');
INSERT INTO Station (station_id, station_name) VALUES (25, 'Mysuru Road');
INSERT INTO Station (station_id, station_name) VALUES (26, 'Deepanjali Nagar');
INSERT INTO Station (station_id, station_name) VALUES (27, 'Attiguppe');
INSERT INTO Station (station_id, station_name) VALUES (28, 'Vijayanagar');
INSERT INTO Station (station_id, station_name) VALUES (29, 'Hosahalli');
INSERT INTO Station (station_id, station_name) VALUES (30, 'Magadi Road');
INSERT INTO Station (station_id, station_name) VALUES (31, 'KSR Railway Station');
INSERT INTO Station (station_id, station_name) VALUES (32, 'Sir M.V.Central College');
INSERT INTO Station (station_id, station_name) VALUES (33, 'Vidhana Soudha');
INSERT INTO Station (station_id, station_name) VALUES (34, 'Cubbon Park');
INSERT INTO Station (station_id, station_name) VALUES (35, 'M.G.Road');
INSERT INTO Station (station_id, station_name) VALUES (36, 'Trinity');
INSERT INTO Station (station_id, station_name) VALUES (37, 'Ulsoor');
INSERT INTO Station (station_id, station_name) VALUES (38, 'Indira Nagar');
INSERT INTO Station (station_id, station_name) VALUES (39, 'S.V.Road');
INSERT INTO Station (station_id, station_name) VALUES (40, 'Baiyyappanahalli');

INSERT INTO Passenger (phone_no, username) VALUES ('1234567890', 'Chandan');
INSERT INTO Passenger (phone_no, username) VALUES ('0987654321', 'Anurag');
INSERT INTO Passenger (phone_no, username) VALUES ('5555555555', 'Chandana');
INSERT INTO Passenger (phone_no, username) VALUES ('6666666666', 'Jeet');
INSERT INTO Passenger (phone_no, username) VALUES ('7777777777', 'Chandana M');

SET IDENTITY_INSERT metrocard ON;

INSERT INTO metrocard (card_id, wallet_balance, phone_no) VALUES (1001,100, '1234567890');
INSERT INTO metrocard (card_id, wallet_balance, phone_no) VALUES (1002, 200, '0987654321');
INSERT INTO metrocard (card_id, wallet_balance, phone_no) VALUES (1003, 150, '5555555555');
INSERT INTO metrocard (card_id, wallet_balance, phone_no) VALUES (1004, 300, '6666666666');
INSERT INTO metrocard (card_id, wallet_balance, phone_no) VALUES (1005, 250, '7777777777');

SET IDENTITY_INSERT metrocard OFF;

SET IDENTITY_INSERT Booking ON;

INSERT INTO Booking (booking_id, source_stn, destination_stn, fare) VALUES (1, 1, 2, 25);
INSERT INTO Booking (booking_id, source_stn, destination_stn, fare) VALUES (2, 2, 3, 40);
INSERT INTO Booking (booking_id, source_stn, destination_stn, fare) VALUES (3, 3, 4, 55);
INSERT INTO Booking (booking_id, source_stn, destination_stn, fare) VALUES (4, 4, 5, 60);
INSERT INTO Booking (booking_id, source_stn, destination_stn, fare) VALUES (5, 5, 1, 20);


create view vwCardDetails
as

SELECT 
    Passenger.phone_no, 
    Passenger.username, 
  metrocard. card_id, 
 metrocard.wallet_balance
FROM 
    Passenger
INNER JOIN 
    metrocard ON Passenger.phone_no = metrocard.phone_no;

--  CREATE TABLE PassengerCard AS
--SELECT 
--    Passenger.phone_no, 
--    Passenger.username, 
--  metrocard. card_id, 
-- metrocard.wallet_balance
--FROM 
--    Passenger
--LEFT JOIN 
--    metrocard ON Passenger.phone_no = metrocard.phone_no;


	select * from vwCardDetails where phone_no = 5555555555
