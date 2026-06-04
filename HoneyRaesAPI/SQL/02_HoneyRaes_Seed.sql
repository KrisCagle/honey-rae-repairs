\c HoneyRaes

INSERT INTO Customer (Name, Address) VALUES ('Kim Donner', '159 Pond Road');
INSERT INTO Customer (Name, Address) VALUES ('Josh Rich', '123 James Street');
INSERT INTO Customer (Name, Address) VALUES ('Bailey Simmons', '435 Norwood Drive');

INSERT INTO Employee (Name, Specialty) VALUES ('Shirley Knowles', 'Mobile');
INSERT INTO Employee (Name, Specialty) VALUES ('Shawn Smith', 'Linux');

INSERT INTO ServiceTicket (CustomerId, EmployeeId, Description, Emergency, DateCompleted) VALUES (1, 1, 'Needs to Fix Apple Phone', true, '2026-03-21');
INSERT INTO ServiceTicket (CustomerId, EmployeeId, Description, Emergency) VALUES (2, 2, 'Needs to Fix Android Phone', false);
INSERT INTO ServiceTicket (CustomerId, EmployeeId, Description, Emergency, DateCompleted) VALUES (3, 2, 'Computer not turning on', true, '2026-02-12');
INSERT INTO ServiceTicket (CustomerId, EmployeeId, Description, Emergency) VALUES (2, 1, 'Computer is a Dell. Advise', true);