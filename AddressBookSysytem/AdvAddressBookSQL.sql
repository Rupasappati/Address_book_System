--UC-1-Create-Address-Book-Service-Database--
create database AddressBookServiceDB;
use AddressBookServiceDB;

--UC-2-Add-Addressbook-Table--
create table AddressBook(
FirstName varchar(100),
LastName varchar(100),
Address varchar(100),
City varchar(100),
State varchar (100),
Zip bigint,
PhoneNumber bigint,
Email varchar(100)
);

select * from AddressBook;

--UC-3-Insert-Contact-Details-Into-Table--
insert into AddressBook(FirstName,LastName,Address,City,State,Zip,PhoneNumber,Email)
values('Rupa','Sappati','Chataparru','Eluru','AP',534004,9398560256,'rupasappati@gmail.com'),
('pushpa','Sappati','chintal','hyd','TS',543543,5343547542,'pushpa@gmail.com'),
('murali','Chandana','balnagar','hyd','TS',234535,5485478751,'murali.ch@gmail.com'),
('Satya','Sappati','Chataparru','Eluru','AP',534004,8978615386,'satya@gmail.com');


select * from AddressBook;

--UC-4-Edit-Contact-By-Person's-Name--
update AddressBook set PhoneNumber=8106798678 where FirstName='pushpa';

select * from AddressBook;

--UC-5-Delete-Existing-Contact-Using-Name--
delete AddressBook where FirstName='murali';

select * from AddressBook;

--UC-6-Retrieve-Person-Belonging-To-City-Or-State--
select * from AddressBook where City = 'Eluru' or State = 'AP';

--UC-7-Size-Of-Addressbook--
select COUNT(*) as StateCount, State from AddressBook group by State;
select COUNT(*) as StateCount, City from AddressBook group by City; 

--UC-8-Sort-Entries-By-Name-Alphabetically--
select * from AddressBook order by FirstName;

--UC-9-Identify-Each-Addressbook-With-Name-And-Type--
alter table Addressbook add ContactType varchar(100) not null default 'Friend';
update AddressBook set ContactType = 'Family' where FirstName = 'pushpa';
select * from AddressBook;


--UC-10-Get-Contact-Count-By-Type--
select COUNT(*) as Type, ContactType from AddressBook group by ContactType;

--UC-11-Add-Person-To-Both-Family-And-Friend--
insert into AddressBook(FirstName,LastName,Address,City,State,Zip,PhoneNumber,Email,ContactType)
values('Shankar','Kommna','kochi','Kerala','Kerala',482002,7999254588,'shankar@gmail.com','Family'),
('pavan','Allu','jalipudi','Eluru','AP',534007,2315648974,'pavansaiallu@gmail.com','Friend'),
('charan','challa','Kammam','Kammam','AP',547775,2154564584,'charan@gmail.com','Friend');
select * from AddressBook;